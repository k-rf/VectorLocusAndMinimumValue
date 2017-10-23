<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VectorLocusAndMinimumValue
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.createVector = New System.Windows.Forms.Button()
        Me.numVector = New System.Windows.Forms.NumericUpDown()
        Me.lblNumberOfVector = New System.Windows.Forms.Label()
        Me.DrawArea = New System.Windows.Forms.PictureBox()
        Me.Locus1 = New System.Windows.Forms.Button()
        Me.numLocus = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblMinValue = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.Reset = New System.Windows.Forms.Button()
        Me.CoefficientView = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Locus2 = New System.Windows.Forms.Button()
        Me.LocusAll = New System.Windows.Forms.Button()
        Me.Granularity = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Clear = New System.Windows.Forms.Button()
        CType(Me.numVector, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DrawArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLocus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Granularity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'createVector
        '
        Me.createVector.Location = New System.Drawing.Point(525, 689)
        Me.createVector.Name = "createVector"
        Me.createVector.Size = New System.Drawing.Size(147, 31)
        Me.createVector.TabIndex = 0
        Me.createVector.Text = "生成"
        Me.createVector.UseVisualStyleBackColor = True
        '
        'numVector
        '
        Me.numVector.Location = New System.Drawing.Point(430, 690)
        Me.numVector.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numVector.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.numVector.Name = "numVector"
        Me.numVector.Size = New System.Drawing.Size(89, 31)
        Me.numVector.TabIndex = 1
        Me.numVector.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'lblNumberOfVector
        '
        Me.lblNumberOfVector.AutoSize = True
        Me.lblNumberOfVector.Location = New System.Drawing.Point(204, 693)
        Me.lblNumberOfVector.Name = "lblNumberOfVector"
        Me.lblNumberOfVector.Size = New System.Drawing.Size(156, 24)
        Me.lblNumberOfVector.TabIndex = 2
        Me.lblNumberOfVector.Text = "合成元ベクトル"
        '
        'DrawArea
        '
        Me.DrawArea.BackColor = System.Drawing.Color.White
        Me.DrawArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DrawArea.Location = New System.Drawing.Point(12, 12)
        Me.DrawArea.Name = "DrawArea"
        Me.DrawArea.Size = New System.Drawing.Size(660, 660)
        Me.DrawArea.TabIndex = 3
        Me.DrawArea.TabStop = False
        '
        'Locus1
        '
        Me.Locus1.Location = New System.Drawing.Point(525, 727)
        Me.Locus1.Name = "Locus1"
        Me.Locus1.Size = New System.Drawing.Size(72, 31)
        Me.Locus1.TabIndex = 4
        Me.Locus1.Text = "1"
        Me.Locus1.UseVisualStyleBackColor = True
        '
        'numLocus
        '
        Me.numLocus.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numLocus.Location = New System.Drawing.Point(430, 727)
        Me.numLocus.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numLocus.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numLocus.Name = "numLocus"
        Me.numLocus.Size = New System.Drawing.Size(89, 31)
        Me.numLocus.TabIndex = 5
        Me.numLocus.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(68, 729)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(292, 24)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "乱係数の合成ベクトルの軌跡"
        '
        'lblMinValue
        '
        Me.lblMinValue.AutoSize = True
        Me.lblMinValue.Location = New System.Drawing.Point(432, 804)
        Me.lblMinValue.Name = "lblMinValue"
        Me.lblMinValue.Size = New System.Drawing.Size(87, 24)
        Me.lblMinValue.TabIndex = 7
        Me.lblMinValue.Text = "1.00000"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(139, 804)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(285, 24)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "合成ベクトルの長さの最小値"
        '
        'ProgressBar
        '
        Me.ProgressBar.BackColor = System.Drawing.Color.Black
        Me.ProgressBar.ForeColor = System.Drawing.Color.White
        Me.ProgressBar.Location = New System.Drawing.Point(12, 671)
        Me.ProgressBar.MarqueeAnimationSpeed = 50
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(660, 5)
        Me.ProgressBar.Step = 1
        Me.ProgressBar.TabIndex = 9
        '
        'Reset
        '
        Me.Reset.Location = New System.Drawing.Point(525, 801)
        Me.Reset.Name = "Reset"
        Me.Reset.Size = New System.Drawing.Size(147, 31)
        Me.Reset.TabIndex = 10
        Me.Reset.Text = "リセット"
        Me.Reset.UseVisualStyleBackColor = True
        '
        'CoefficientView
        '
        Me.CoefficientView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.CoefficientView.Location = New System.Drawing.Point(678, 12)
        Me.CoefficientView.Name = "CoefficientView"
        Me.CoefficientView.Size = New System.Drawing.Size(163, 820)
        Me.CoefficientView.TabIndex = 11
        Me.CoefficientView.UseCompatibleStateImageBehavior = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "係数"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "値"
        Me.ColumnHeader2.Width = 99
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(68, 767)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(292, 24)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "全係数の合成ベクトルの軌跡"
        '
        'Locus2
        '
        Me.Locus2.Location = New System.Drawing.Point(600, 727)
        Me.Locus2.Name = "Locus2"
        Me.Locus2.Size = New System.Drawing.Size(72, 31)
        Me.Locus2.TabIndex = 13
        Me.Locus2.Text = "2"
        Me.Locus2.UseVisualStyleBackColor = True
        '
        'LocusAll
        '
        Me.LocusAll.Location = New System.Drawing.Point(525, 764)
        Me.LocusAll.Name = "LocusAll"
        Me.LocusAll.Size = New System.Drawing.Size(72, 31)
        Me.LocusAll.TabIndex = 14
        Me.LocusAll.Text = "描画"
        Me.LocusAll.UseVisualStyleBackColor = True
        '
        'Granularity
        '
        Me.Granularity.Location = New System.Drawing.Point(430, 765)
        Me.Granularity.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.Granularity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Granularity.Name = "Granularity"
        Me.Granularity.Size = New System.Drawing.Size(89, 31)
        Me.Granularity.TabIndex = 15
        Me.Granularity.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(390, 692)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 24)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "数"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(390, 729)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 24)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "数"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(366, 767)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 24)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "粒度"
        '
        'Clear
        '
        Me.Clear.Location = New System.Drawing.Point(603, 764)
        Me.Clear.Name = "Clear"
        Me.Clear.Size = New System.Drawing.Size(69, 31)
        Me.Clear.TabIndex = 19
        Me.Clear.Text = "クリア"
        Me.Clear.UseVisualStyleBackColor = True
        '
        'VectorLocusAndMinimumValue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 842)
        Me.Controls.Add(Me.Clear)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Granularity)
        Me.Controls.Add(Me.LocusAll)
        Me.Controls.Add(Me.Locus2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CoefficientView)
        Me.Controls.Add(Me.Reset)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblMinValue)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.numLocus)
        Me.Controls.Add(Me.Locus1)
        Me.Controls.Add(Me.lblNumberOfVector)
        Me.Controls.Add(Me.numVector)
        Me.Controls.Add(Me.createVector)
        Me.Controls.Add(Me.DrawArea)
        Me.Controls.Add(Me.ProgressBar)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.MaximizeBox = False
        Me.Name = "VectorLocusAndMinimumValue"
        Me.Text = "VectorLocusAndMinimumValue"
        CType(Me.numVector, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DrawArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLocus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Granularity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents createVector As Button
    Friend WithEvents numVector As NumericUpDown
    Friend WithEvents lblNumberOfVector As Label
    Friend WithEvents DrawArea As PictureBox
    Friend WithEvents Locus1 As Button
    Friend WithEvents numLocus As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents lblMinValue As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ProgressBar As ProgressBar
    Friend WithEvents Reset As Button
    Friend WithEvents CoefficientView As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents Label3 As Label
    Friend WithEvents Locus2 As Button
    Friend WithEvents LocusAll As Button
    Friend WithEvents Granularity As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Clear As Button
End Class
