Public Class VectorLocusAndMinimumValue
    Const scale_size As Integer = 300
    Const valid_digits As String = "0.00000"
    Const lowest_nest As Integer = 1

    Dim rnd As New Random

    Dim origin As Point

    Dim theta() As Double
    Dim vector() As PointF
    Dim preserve_num_vector As Integer

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

        For i As Integer = 0 To preserve_num_vector - 1
            DrawVector(i)
            UpdateListView(i)
        Next

        DrawArea.Refresh()

        AddHandler DrawArea.Paint, AddressOf Me.Origin_Paint
    End Sub


    Private Sub CreateVector_Click(sender As Object, e As EventArgs) Handles createVector.Click
        UpdateData()

        ' ベクトルの数が変わっているかもしれないので，一度ListViewを削除する
        Me.CoefficientView.Items.Clear()

        ProgressBar.Maximum = preserve_num_vector - 1
        For i As Integer = 0 To preserve_num_vector - 1
            DrawVector(i)
            UpdateListView(i)

            ProgressBar.Value = i
        Next

        DrawArea.Refresh()
    End Sub


    Private Sub Locus1_Click(sender As Object, e As EventArgs) Handles Locus1.Click
        ProgressBar.Maximum = numLocus.Value - 1
        For i As Integer = 0 To numLocus.Value - 1
            GetRandomCoefficient_1()
            DrawPoint()
            lblMinValue.Text = Format(min_value.Value, valid_digits)

            ProgressBar.Value = i
        Next

        DrawArea.Refresh()

        For i As Integer = 0 To preserve_num_vector - 1
            Me.CoefficientView.Items(i).SubItems(1).Text = Format(min_value.Condition(i), valid_digits)
        Next
    End Sub


    Private Sub Locus2_Click(sender As Object, e As EventArgs) Handles Locus2.Click
        ProgressBar.Maximum = numLocus.Value - 1
        For i As Integer = 0 To numLocus.Value - 1
            GetRandomCoefficient_2()
            DrawPoint()
            lblMinValue.Text = Format(min_value.Value, valid_digits)

            ProgressBar.Value = i
        Next

        DrawArea.Refresh()

        For i As Integer = 0 To preserve_num_vector - 1
            Me.CoefficientView.Items(i).SubItems(1).Text = Format(min_value.Condition(i), valid_digits)
        Next

    End Sub


    Private Sub LocusAll_Click(sender As Object, e As EventArgs) Handles LocusAll.Click
        ' ネスト最下層にたどり着くすべての組み合わせの数
        ProgressBar.Maximum =
            Combination(Granularity.Value + preserve_num_vector - 1, Math.Min(Granularity.Value, preserve_num_vector - 1))
        ProgressBar.Value = 0

        boundary(0) = Granularity.Value ' 粒度(Granularity)
        DrawAll(1, 0, preserve_num_vector - 1)

        For i As Integer = 0 To preserve_num_vector - 1
            Me.CoefficientView.Items(i).SubItems(1).Text = Format(min_value.Condition(i), valid_digits)
        Next
        lblMinValue.Text = Format(min_value.Value, valid_digits)
        DrawArea.Refresh()
    End Sub


    Private Sub Clear_Click(sender As Object, e As EventArgs) Handles Clear.Click
        Me.DrawArea.Image.Dispose()
        Me.DrawArea.Image = New Bitmap(Me.DrawArea.Width, Me.DrawArea.Height)

        ProgressBar.Maximum = preserve_num_vector - 1
        For i As Integer = 0 To preserve_num_vector - 1
            ProgressBar.Value = i
            DrawVector(i)
        Next

        DrawArea.Refresh()
    End Sub


    Private Sub Reset_Click(sender As Object, e As EventArgs) Handles Reset.Click
        numVector.Value = numVector.Minimum
        numLocus.Value = numLocus.Minimum
        Granularity.Value = Granularity.Minimum

        UpdateData()

        Me.CoefficientView.Items.Clear()

        ProgressBar.Maximum = preserve_num_vector - 1
        For i As Integer = 0 To preserve_num_vector - 1
            DrawVector(i)
            UpdateListView(i)

            ProgressBar.Value = i
        Next

        DrawArea.Refresh()
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
        For i As Integer = 0 To Me.preserve_num_vector - 1
            sum_vector.X += Me.coefficient(i) * Me.vector(i).X
            sum_vector.Y += Me.coefficient(i) * Me.vector(i).Y
        Next

        Dim dst_x As Integer = CInt(Me.origin.X + scale_size * sum_vector.X)
        Dim dst_y As Integer = CInt(Me.origin.Y + scale_size * sum_vector.Y)

        Dim distance As Double = Math.Pow(sum_vector.X, 2) + Math.Pow(sum_vector.Y, 2)
        If min_value.Value > distance Then
            min_value.Value = distance
            For i As Integer = 0 To Me.preserve_num_vector - 1
                min_value.PreserveCoefficient(i, Me.coefficient(i))
            Next
        End If

        g.DrawRectangle(Pens.Red, dst_x, dst_y, 1, 1)
    End Sub


    ' 粒度を基に取り得る点をすべて描画
    Private Sub DrawAll(ByVal idx_a As Integer, ByVal idx_b As Integer, ByVal nest As Integer)
        If nest < lowest_nest Then ' ネスト最下層
            Return
        End If

        boundary(idx_a) = 0
        While (boundary(idx_a) <= boundary(idx_b))
            DrawAll(idx_a + 1, idx_a, nest - 1)

            If nest = lowest_nest Then
                For i As Integer = 0 To preserve_num_vector - 2
                    coefficient(i) = boundary(i) - boundary(i + 1)
                    coefficient(i) /= Granularity.Value
                Next
                ' インデックスが範囲外になるため (c = b - 0 ==> c = b)
                coefficient(preserve_num_vector - 1) = boundary(preserve_num_vector - 1)
                coefficient(preserve_num_vector - 1) /= Granularity.Value

                DrawPoint()
                'DrawArea.Refresh()

                ProgressBar.Value += 1
            End If

            boundary(idx_a) += 1
        End While
    End Sub


    ' =========================================================================
    ' 乱数系サブルーチン
    ' =========================================================================

    ' π の値を生成
    Private Sub GetRandomPi(ByRef ary() As Double)
        For i As Integer = 0 To ary.Length - 1
            ary(i) = 2 * Math.PI * rnd.NextDouble
        Next
    End Sub


    ' 乱数生成 Ver. 1
    Private Sub GetRandomCoefficient_1()
        Dim tmp_i As Integer = 0

        For i As Integer = 0 To Me.preserve_num_vector - 2
            tmp_i = rnd.Next(tmp_i, 100000000)
            Me.boundary(i) = tmp_i / 100000000
        Next
        Me.boundary(preserve_num_vector - 1) = 1

        Dim tmp_d As Double = 0
        For i As Integer = 0 To Me.preserve_num_vector - 1
            Me.coefficient(i) = Me.boundary(i) - tmp_d
            tmp_d = Me.boundary(i)
        Next
    End Sub


    ' 乱数生成 Ver. 2
    Private Sub GetRandomCoefficient_2()
        Dim sum_boundary As Integer = 0

        While sum_boundary = 0
            For i As Integer = 0 To Me.preserve_num_vector - 1
                Me.boundary(i) = rnd.Next(1000)
                sum_boundary += Me.boundary(i)
            Next
        End While

        For i As Integer = 0 To Me.preserve_num_vector - 1
            Me.coefficient(i) = Me.boundary(i) / sum_boundary
        Next
    End Sub


    ' =========================================================================
    ' その他のサブルーチン
    ' =========================================================================

    Private Sub Realloc(Of T)(ByRef ary() As T, ByVal size As Integer)
        ReDim ary(size)
    End Sub


    Private Sub DicideElement()
        For i As Integer = 0 To Me.vector.Length - 1
            Me.vector(i).X = Math.Cos(Me.theta(i))
            Me.vector(i).Y = Math.Sin(Me.theta(i))
        Next
    End Sub


    Private Sub UpdateListView(ByVal i As Integer)
        Me.CoefficientView.Items.Add("C_" & (i + 1), i)
        Me.CoefficientView.Items(i).SubItems.Add(Format(min_value.Condition(i), valid_digits))
    End Sub


    Private Function Combination(ByVal n As Integer, ByVal r As Integer) As Integer
        Dim answer As Integer = 1
        For i As Integer = 1 To r
            answer = answer * (n - i + 1) / i
        Next

        Return answer
    End Function


    ' =========================================================================
    ' 一連の処理
    ' =========================================================================

    Private Sub UpdateData()
        preserve_num_vector = Me.numVector.Value

        Me.Realloc(Me.theta, Me.numVector.Value)
        Me.GetRandomPi(Me.theta)

        Realloc(Me.vector, Me.numVector.Value)
        DicideElement()

        Realloc(Me.boundary, Me.numVector.Value)
        Realloc(Me.coefficient, Me.numVector.Value)
        GetRandomCoefficient_1()

        Me.DrawArea.Image.Dispose()
        Me.DrawArea.Image = New Bitmap(Me.DrawArea.Width, Me.DrawArea.Height)

        min_value.Value = 1
        min_value.Realloc(Me.numVector.Value)

        Me.lblMinValue.Text = Format(1, valid_digits)
    End Sub
End Class
