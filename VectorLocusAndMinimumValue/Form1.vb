Public Class VectorLocusAndMinimumValue
    Const scale_size As Integer = 300
    Const valid_digits As String = "0.00000"
    Const lowest_nest As Integer = 1

    Dim rnd As New Random

    Dim origin As Point

    Dim theta() As Double
    Dim vector() As PointF

    Dim boundary() As Double ' coefficientを求めるために利用
    Dim coefficient() As Double

    ' -------------------------------------------------------------------------
    ' 合成ベクトルの最小値を保存するクラス
    ' -------------------------------------------------------------------------
    Public Class MinimumValue
        Dim min_value As Double = 1
        Dim min_coefficient() As Double

        Property Value
            Get
                Return min_value
            End Get
            Set(value)
                min_value = value
            End Set
        End Property

        ReadOnly Property Condition(ByVal i As Integer)
            Get
                Return min_coefficient(i)
            End Get
        End Property

        Public Sub PreserveCoefficient(ByVal i As Integer, ByVal v As Double)
            Me.min_coefficient(i) = v
        End Sub

        Public Sub Realloc(ByVal size As Integer)
            ReDim Me.min_coefficient(size)
        End Sub
    End Class

    Dim min_value As New MinimumValue


    ' =========================================================================
    ' イベント
    ' =========================================================================
    Private Sub VectorLocusAndMinimumValue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 原点の座標を設定
        origin = New Point(DrawArea.Width / 2, DrawArea.Height / 2)

        ' 描画エリアのインスタンスを作成
        Me.DrawArea.Image = New Bitmap(Me.DrawArea.Width, Me.DrawArea.Height)

        ' ListView を詳細表示に設定
        Me.CoefficientView.View = View.Details

        UpdateData()

        For i As Integer = 0 To numVector.Value - 1
            DrawVector(i)
            DrawArea.Refresh()

            Me.CoefficientView.Items.Add("C_" & i + 1, i)
            Me.CoefficientView.Items(i).SubItems.Add(Format(min_value.Condition(i), valid_digits))
        Next

        AddHandler DrawArea.Paint, AddressOf Me.Origin_Paint
    End Sub


    Private Sub CreateVector_Click(sender As Object, e As EventArgs) Handles createVector.Click
        UpdateData()

        Me.CoefficientView.Items.Clear()
        ProgressBar.Maximum = numVector.Value - 1
        For i As Integer = 0 To numVector.Value - 1
            ProgressBar.Value = i
            DrawVector(i)
            DrawArea.Refresh()

            Me.CoefficientView.Items.Add("C_" & i + 1, i)
            Me.CoefficientView.Items(i).SubItems.Add(Format(Me.coefficient(i), valid_digits))

        Next
    End Sub


    Private Sub Locus_Click(sender As Object, e As EventArgs) Handles Locus.Click
        ProgressBar.Maximum = numLocus.Value - 1
        For i As Integer = 0 To numLocus.Value - 1
            ProgressBar.Value = i
            DecideCoefficient()
            DrawPoint()
            DrawArea.Refresh()
            lblMinValue.Text = Format(min_value.Value, valid_digits)
        Next

        For i As Integer = 0 To numVector.Value - 1
            Me.CoefficientView.Items(i).SubItems(1).Text = Format(min_value.Condition(i), valid_digits)
        Next
    End Sub


    Private Sub Reset_Click(sender As Object, e As EventArgs) Handles Reset.Click
        numVector.Value = numVector.Minimum
        numLocus.Value = numLocus.Minimum

        UpdateData()

        Me.CoefficientView.Items.Clear()
        ProgressBar.Maximum = numVector.Value - 1
        For i As Integer = 0 To numVector.Value - 1
            ProgressBar.Value = i
            DrawVector(i)
            DrawArea.Refresh()

            Me.CoefficientView.Items.Add("C_" & i + 1, i)
            Me.CoefficientView.Items(i).SubItems.Add(Format(Me.coefficient(i), valid_digits))
        Next
    End Sub


    ' =========================================================================
    ' 描画系サブルーチン
    ' =========================================================================

    Private Sub Origin_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(Brushes.Orange, Me.origin.X - 3, Me.origin.Y - 3, 6, 6)
    End Sub

    Private Sub DrawVector(ByVal i As Integer)
        Dim g As Graphics = Graphics.FromImage(Me.DrawArea.Image)

        Dim dst_x As Integer = CInt(Me.origin.X + scale_size * Me.vector(i).X)
        Dim dst_y As Integer = CInt(Me.origin.Y + scale_size * Me.vector(i).Y)

        g.DrawLine(Pens.Black, Me.origin.X, Me.origin.Y, dst_x, dst_y)
    End Sub


    Private Sub DrawPoint()
        Dim g As Graphics = Graphics.FromImage(Me.DrawArea.Image)

        Dim sum_vector As New PointF(0, 0)
        For i As Integer = 0 To Me.numVector.Value - 1
            sum_vector.X += Me.coefficient(i) * Me.vector(i).X
            sum_vector.Y += Me.coefficient(i) * Me.vector(i).Y
        Next

        Dim dst_x As Integer = CInt(Me.origin.X + scale_size * sum_vector.X)
        Dim dst_y As Integer = CInt(Me.origin.Y + scale_size * sum_vector.Y)

        Dim distance As Double = Math.Pow(sum_vector.X, 2) + Math.Pow(sum_vector.Y, 2)
        If min_value.Value > distance Then
            min_value.Value = distance
            For i As Integer = 0 To Me.numVector.Value - 1
                min_value.PreserveCoefficient(i, Me.coefficient(i))
            Next
        End If

        g.DrawRectangle(Pens.Red, dst_x, dst_y, 1, 1)
    End Sub


    ' =========================================================================
    ' その他のサブルーチン
    ' =========================================================================

    Private Sub Realloc(Of T)(ByRef ary() As T, ByVal size As Integer)
        ReDim ary(size)
    End Sub


    Private Sub Randomize(ByRef ary() As Double)
        For i As Integer = 0 To ary.Length - 1
            ary(i) = 2 * Math.PI * rnd.NextDouble
        Next
    End Sub


    Private Sub DicideElement()
        For i As Integer = 0 To Me.vector.Length - 1
            Me.vector(i).X = Math.Cos(Me.theta(i))
            Me.vector(i).Y = Math.Sin(Me.theta(i))
        Next
    End Sub


    Private Sub DuplicateCombination(ByVal idx_a As Integer, ByVal idx_b As Integer, ByVal nest As Integer)
        If nest < lowest_nest Then
            Return
        End If

        boundary(idx_a) = 0
        While (boundary(idx_a) <= boundary(idx_b))
            DuplicateCombination(idx_a + 1, idx_a, nest - 1)

            If nest = lowest_nest Then
                For i As Integer = 0 To numVector.Value - 2
                    coefficient(i) = boundary(i) - boundary(i + 1)
                Next
                coefficient(numVector.Value - 1) = boundary(numVector.Value - 1)

                DrawPoint()
                DrawArea.Refresh()
            End If

            boundary(idx_a) += 1
        End While
    End Sub


    Private Sub DecideCoefficient()
        Dim sum_boundary As Integer = 0

        ' 乱数生成 Ver. 1
        'For i As Integer = 0 To Me.numVector.Value - 2
        '    tmp_i = rnd.Next(tmp_i, 100000000)
        '    Me.boundary(i) = tmp_i / 100000000
        'Next
        'Me.boundary(numVector.Value - 1) = 1

        'Dim tmp_d As Double = 0
        'For i As Integer = 0 To Me.numVector.Value - 1
        '    Me.coefficient(i) = Me.boundary(i) - tmp_d
        '    tmp_d = Me.boundary(i)
        'Next


        ' 乱数生成 Ver. 2
        While sum_boundary = 0
            For i As Integer = 0 To Me.numVector.Value - 1
                Me.boundary(i) = rnd.Next(10000000)
                sum_boundary += Me.boundary(i)
            Next
        End While

        For i As Integer = 0 To Me.numVector.Value - 1
            Me.coefficient(i) = Me.boundary(i) / sum_boundary
        Next


        ' 乱数生成 Ver. 3
        'boundary(0) = 100

        'DuplicateCombination(1, 0, numVector.Value - 1)


        'Me.DrawPoint()
    End Sub


    ' =========================================================================
    ' 一連の処理
    ' =========================================================================

    Private Sub UpdateData()
        Me.Realloc(Me.theta, Me.numVector.Value)
        Me.Randomize(Me.theta)

        Realloc(Me.vector, Me.numVector.Value)
        DicideElement()

        Realloc(Me.boundary, Me.numVector.Value)
        Realloc(Me.coefficient, Me.numVector.Value)
        DecideCoefficient()

        Me.DrawArea.Image.Dispose()
        Me.DrawArea.Image = New Bitmap(Me.DrawArea.Width, Me.DrawArea.Height)

        min_value.Value = 1
        min_value.Realloc(Me.numVector.Value)

        Me.lblMinValue.Text = Format(1, valid_digits)
    End Sub
End Class
