<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BeheerStudent
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cboStudentNaam = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.BeheerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cboNaamData = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNaam = New System.Windows.Forms.TextBox
        Me.txtPriveMail = New System.Windows.Forms.TextBox
        Me.txtGebDatum = New System.Windows.Forms.TextBox
        Me.txtFinRek = New System.Windows.Forms.TextBox
        Me.txtSchoolMail = New System.Windows.Forms.TextBox
        Me.txtGSM = New System.Windows.Forms.TextBox
        Me.txtVoornaam = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.btnStudentMail = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboStudentNaam
        '
        Me.cboStudentNaam.FormattingEnabled = True
        Me.cboStudentNaam.Location = New System.Drawing.Point(161, 47)
        Me.cboStudentNaam.Name = "cboStudentNaam"
        Me.cboStudentNaam.Size = New System.Drawing.Size(121, 21)
        Me.cboStudentNaam.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 105)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Student Naam"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BeheerToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(287, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'BeheerToolStripMenuItem
        '
        Me.BeheerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DetailToolStripMenuItem, Me.NewToolStripMenuItem, Me.EditToolStripMenuItem, Me.SaveToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.CancelToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.BeheerToolStripMenuItem.Name = "BeheerToolStripMenuItem"
        Me.BeheerToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.BeheerToolStripMenuItem.Text = "Beheer"
        '
        'DetailToolStripMenuItem
        '
        Me.DetailToolStripMenuItem.Name = "DetailToolStripMenuItem"
        Me.DetailToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.DetailToolStripMenuItem.Text = "Detail"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.CancelToolStripMenuItem.Text = "Cancel"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'cboNaamData
        '
        Me.cboNaamData.FormattingEnabled = True
        Me.cboNaamData.Location = New System.Drawing.Point(161, 105)
        Me.cboNaamData.Name = "cboNaamData"
        Me.cboNaamData.Size = New System.Drawing.Size(121, 21)
        Me.cboNaamData.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Zoeken op naam/voornaam"
        '
        'txtNaam
        '
        Me.txtNaam.Location = New System.Drawing.Point(128, 154)
        Me.txtNaam.Name = "txtNaam"
        Me.txtNaam.Size = New System.Drawing.Size(154, 20)
        Me.txtNaam.TabIndex = 5
        '
        'txtPriveMail
        '
        Me.txtPriveMail.Location = New System.Drawing.Point(128, 258)
        Me.txtPriveMail.Name = "txtPriveMail"
        Me.txtPriveMail.Size = New System.Drawing.Size(154, 20)
        Me.txtPriveMail.TabIndex = 6
        '
        'txtGebDatum
        '
        Me.txtGebDatum.Location = New System.Drawing.Point(128, 284)
        Me.txtGebDatum.Name = "txtGebDatum"
        Me.txtGebDatum.Size = New System.Drawing.Size(154, 20)
        Me.txtGebDatum.TabIndex = 7
        '
        'txtFinRek
        '
        Me.txtFinRek.Location = New System.Drawing.Point(128, 310)
        Me.txtFinRek.Name = "txtFinRek"
        Me.txtFinRek.Size = New System.Drawing.Size(154, 20)
        Me.txtFinRek.TabIndex = 8
        '
        'txtSchoolMail
        '
        Me.txtSchoolMail.Location = New System.Drawing.Point(128, 232)
        Me.txtSchoolMail.Name = "txtSchoolMail"
        Me.txtSchoolMail.Size = New System.Drawing.Size(154, 20)
        Me.txtSchoolMail.TabIndex = 9
        '
        'txtGSM
        '
        Me.txtGSM.Location = New System.Drawing.Point(128, 206)
        Me.txtGSM.Name = "txtGSM"
        Me.txtGSM.Size = New System.Drawing.Size(154, 20)
        Me.txtGSM.TabIndex = 10
        '
        'txtVoornaam
        '
        Me.txtVoornaam.Location = New System.Drawing.Point(128, 180)
        Me.txtVoornaam.Name = "txtVoornaam"
        Me.txtVoornaam.Size = New System.Drawing.Size(154, 20)
        Me.txtVoornaam.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 154)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Naam"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 232)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "School-mail"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 310)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Financi�le rekening"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(18, 284)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Geboorte datum"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(18, 258)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Priv�-mail"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 206)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "GSM-Nummer"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(18, 180)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Voornaam"
        '
        'btnStudentMail
        '
        Me.btnStudentMail.Location = New System.Drawing.Point(128, 351)
        Me.btnStudentMail.Name = "btnStudentMail"
        Me.btnStudentMail.Size = New System.Drawing.Size(121, 23)
        Me.btnStudentMail.TabIndex = 21
        Me.btnStudentMail.Text = "Student E-mailen"
        Me.btnStudentMail.UseVisualStyleBackColor = True
        '
        'BeheerStudent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(287, 400)
        Me.Controls.Add(Me.btnStudentMail)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtVoornaam)
        Me.Controls.Add(Me.txtGSM)
        Me.Controls.Add(Me.txtSchoolMail)
        Me.Controls.Add(Me.txtFinRek)
        Me.Controls.Add(Me.txtGebDatum)
        Me.Controls.Add(Me.txtPriveMail)
        Me.Controls.Add(Me.txtNaam)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboNaamData)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboStudentNaam)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "BeheerStudent"
        Me.Text = "BeheerStudent"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboStudentNaam As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents BeheerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DetailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboNaamData As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNaam As System.Windows.Forms.TextBox
    Friend WithEvents txtPriveMail As System.Windows.Forms.TextBox
    Friend WithEvents txtGebDatum As System.Windows.Forms.TextBox
    Friend WithEvents txtFinRek As System.Windows.Forms.TextBox
    Friend WithEvents txtSchoolMail As System.Windows.Forms.TextBox
    Friend WithEvents txtGSM As System.Windows.Forms.TextBox
    Friend WithEvents txtVoornaam As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnStudentMail As System.Windows.Forms.Button
End Class
