<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBeheerStudent
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.BeheerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.txtNaam = New System.Windows.Forms.TextBox
        Me.txtPriveMail = New System.Windows.Forms.TextBox
        Me.txtFinRek = New System.Windows.Forms.TextBox
        Me.txtSchoolMail = New System.Windows.Forms.TextBox
        Me.txtGSM = New System.Windows.Forms.TextBox
        Me.txtVoornaam = New System.Windows.Forms.TextBox
        Me.lblNaam = New System.Windows.Forms.Label
        Me.lblSchoolMail = New System.Windows.Forms.Label
        Me.lblFinRek = New System.Windows.Forms.Label
        Me.lblGebDat = New System.Windows.Forms.Label
        Me.lblPriveMail = New System.Windows.Forms.Label
        Me.lblGSM = New System.Windows.Forms.Label
        Me.lblVoornaam = New System.Windows.Forms.Label
        Me.btnStudentMail = New System.Windows.Forms.Button
        Me.dtpGebDat = New System.Windows.Forms.DateTimePicker
        Me.grpStudentDetails = New System.Windows.Forms.GroupBox
        Me.lblStudNaam = New System.Windows.Forms.Label
        Me.cboNaamData = New System.Windows.Forms.ComboBox
        Me.cboNaamFilter = New System.Windows.Forms.ComboBox
        Me.lblZoekenOp = New System.Windows.Forms.Label
        Me.grpNieuweDeelname = New System.Windows.Forms.GroupBox
        Me.pctGeldigeRekening = New System.Windows.Forms.PictureBox
        Me.lblGeldigeRekening = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.grpStudentDetails.SuspendLayout()
        Me.grpNieuweDeelname.SuspendLayout()
        CType(Me.pctGeldigeRekening, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BeheerToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(514, 24)
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
        'txtNaam
        '
        Me.txtNaam.Location = New System.Drawing.Point(116, 21)
        Me.txtNaam.Name = "txtNaam"
        Me.txtNaam.Size = New System.Drawing.Size(180, 20)
        Me.txtNaam.TabIndex = 2
        '
        'txtPriveMail
        '
        Me.txtPriveMail.Location = New System.Drawing.Point(116, 123)
        Me.txtPriveMail.Name = "txtPriveMail"
        Me.txtPriveMail.Size = New System.Drawing.Size(180, 20)
        Me.txtPriveMail.TabIndex = 6
        '
        'txtFinRek
        '
        Me.txtFinRek.Location = New System.Drawing.Point(116, 175)
        Me.txtFinRek.Name = "txtFinRek"
        Me.txtFinRek.Size = New System.Drawing.Size(180, 20)
        Me.txtFinRek.TabIndex = 8
        '
        'txtSchoolMail
        '
        Me.txtSchoolMail.Location = New System.Drawing.Point(116, 96)
        Me.txtSchoolMail.Name = "txtSchoolMail"
        Me.txtSchoolMail.Size = New System.Drawing.Size(180, 20)
        Me.txtSchoolMail.TabIndex = 5
        '
        'txtGSM
        '
        Me.txtGSM.Location = New System.Drawing.Point(116, 72)
        Me.txtGSM.Name = "txtGSM"
        Me.txtGSM.Size = New System.Drawing.Size(180, 20)
        Me.txtGSM.TabIndex = 4
        '
        'txtVoornaam
        '
        Me.txtVoornaam.Location = New System.Drawing.Point(116, 47)
        Me.txtVoornaam.Name = "txtVoornaam"
        Me.txtVoornaam.Size = New System.Drawing.Size(180, 20)
        Me.txtVoornaam.TabIndex = 3
        '
        'lblNaam
        '
        Me.lblNaam.AutoSize = True
        Me.lblNaam.Location = New System.Drawing.Point(6, 24)
        Me.lblNaam.Name = "lblNaam"
        Me.lblNaam.Size = New System.Drawing.Size(35, 13)
        Me.lblNaam.TabIndex = 12
        Me.lblNaam.Text = "Naam"
        '
        'lblSchoolMail
        '
        Me.lblSchoolMail.AutoSize = True
        Me.lblSchoolMail.Location = New System.Drawing.Point(7, 99)
        Me.lblSchoolMail.Name = "lblSchoolMail"
        Me.lblSchoolMail.Size = New System.Drawing.Size(61, 13)
        Me.lblSchoolMail.TabIndex = 14
        Me.lblSchoolMail.Text = "School-mail"
        '
        'lblFinRek
        '
        Me.lblFinRek.AutoSize = True
        Me.lblFinRek.Location = New System.Drawing.Point(6, 178)
        Me.lblFinRek.Name = "lblFinRek"
        Me.lblFinRek.Size = New System.Drawing.Size(99, 13)
        Me.lblFinRek.TabIndex = 16
        Me.lblFinRek.Text = "Financi�le rekening"
        '
        'lblGebDat
        '
        Me.lblGebDat.AutoSize = True
        Me.lblGebDat.Location = New System.Drawing.Point(6, 152)
        Me.lblGebDat.Name = "lblGebDat"
        Me.lblGebDat.Size = New System.Drawing.Size(80, 13)
        Me.lblGebDat.TabIndex = 17
        Me.lblGebDat.Text = "Geboortedatum"
        '
        'lblPriveMail
        '
        Me.lblPriveMail.AutoSize = True
        Me.lblPriveMail.Location = New System.Drawing.Point(6, 126)
        Me.lblPriveMail.Name = "lblPriveMail"
        Me.lblPriveMail.Size = New System.Drawing.Size(52, 13)
        Me.lblPriveMail.TabIndex = 18
        Me.lblPriveMail.Text = "Priv�-mail"
        '
        'lblGSM
        '
        Me.lblGSM.AutoSize = True
        Me.lblGSM.Location = New System.Drawing.Point(6, 75)
        Me.lblGSM.Name = "lblGSM"
        Me.lblGSM.Size = New System.Drawing.Size(73, 13)
        Me.lblGSM.TabIndex = 19
        Me.lblGSM.Text = "GSM-Nummer"
        '
        'lblVoornaam
        '
        Me.lblVoornaam.AutoSize = True
        Me.lblVoornaam.Location = New System.Drawing.Point(6, 50)
        Me.lblVoornaam.Name = "lblVoornaam"
        Me.lblVoornaam.Size = New System.Drawing.Size(55, 13)
        Me.lblVoornaam.TabIndex = 20
        Me.lblVoornaam.Text = "Voornaam"
        '
        'btnStudentMail
        '
        Me.btnStudentMail.Location = New System.Drawing.Point(9, 215)
        Me.btnStudentMail.Name = "btnStudentMail"
        Me.btnStudentMail.Size = New System.Drawing.Size(121, 23)
        Me.btnStudentMail.TabIndex = 9
        Me.btnStudentMail.Text = "Student E-mailen"
        Me.btnStudentMail.UseVisualStyleBackColor = True
        '
        'dtpGebDat
        '
        Me.dtpGebDat.Location = New System.Drawing.Point(116, 148)
        Me.dtpGebDat.Name = "dtpGebDat"
        Me.dtpGebDat.Size = New System.Drawing.Size(180, 20)
        Me.dtpGebDat.TabIndex = 21
        '
        'grpStudentDetails
        '
        Me.grpStudentDetails.Controls.Add(Me.pctGeldigeRekening)
        Me.grpStudentDetails.Controls.Add(Me.lblGeldigeRekening)
        Me.grpStudentDetails.Controls.Add(Me.lblNaam)
        Me.grpStudentDetails.Controls.Add(Me.btnStudentMail)
        Me.grpStudentDetails.Controls.Add(Me.txtVoornaam)
        Me.grpStudentDetails.Controls.Add(Me.dtpGebDat)
        Me.grpStudentDetails.Controls.Add(Me.txtGSM)
        Me.grpStudentDetails.Controls.Add(Me.txtNaam)
        Me.grpStudentDetails.Controls.Add(Me.lblGebDat)
        Me.grpStudentDetails.Controls.Add(Me.lblVoornaam)
        Me.grpStudentDetails.Controls.Add(Me.lblGSM)
        Me.grpStudentDetails.Controls.Add(Me.lblFinRek)
        Me.grpStudentDetails.Controls.Add(Me.lblSchoolMail)
        Me.grpStudentDetails.Controls.Add(Me.lblPriveMail)
        Me.grpStudentDetails.Controls.Add(Me.txtFinRek)
        Me.grpStudentDetails.Controls.Add(Me.txtSchoolMail)
        Me.grpStudentDetails.Controls.Add(Me.txtPriveMail)
        Me.grpStudentDetails.Location = New System.Drawing.Point(17, 158)
        Me.grpStudentDetails.Name = "grpStudentDetails"
        Me.grpStudentDetails.Size = New System.Drawing.Size(482, 255)
        Me.grpStudentDetails.TabIndex = 23
        Me.grpStudentDetails.TabStop = False
        Me.grpStudentDetails.Text = "Studentdetails"
        '
        'lblStudNaam
        '
        Me.lblStudNaam.AutoSize = True
        Me.lblStudNaam.Location = New System.Drawing.Point(6, 53)
        Me.lblStudNaam.Name = "lblStudNaam"
        Me.lblStudNaam.Size = New System.Drawing.Size(75, 13)
        Me.lblStudNaam.TabIndex = 1
        Me.lblStudNaam.Text = "Student Naam"
        '
        'cboNaamData
        '
        Me.cboNaamData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNaamData.FormattingEnabled = True
        Me.cboNaamData.Location = New System.Drawing.Point(116, 50)
        Me.cboNaamData.Name = "cboNaamData"
        Me.cboNaamData.Size = New System.Drawing.Size(180, 21)
        Me.cboNaamData.TabIndex = 1
        '
        'cboNaamFilter
        '
        Me.cboNaamFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNaamFilter.FormattingEnabled = True
        Me.cboNaamFilter.Location = New System.Drawing.Point(116, 23)
        Me.cboNaamFilter.Name = "cboNaamFilter"
        Me.cboNaamFilter.Size = New System.Drawing.Size(180, 21)
        Me.cboNaamFilter.TabIndex = 0
        '
        'lblZoekenOp
        '
        Me.lblZoekenOp.AutoSize = True
        Me.lblZoekenOp.Location = New System.Drawing.Point(6, 26)
        Me.lblZoekenOp.Name = "lblZoekenOp"
        Me.lblZoekenOp.Size = New System.Drawing.Size(62, 13)
        Me.lblZoekenOp.TabIndex = 4
        Me.lblZoekenOp.Text = "Zoeken op:"
        '
        'grpNieuweDeelname
        '
        Me.grpNieuweDeelname.Controls.Add(Me.lblZoekenOp)
        Me.grpNieuweDeelname.Controls.Add(Me.cboNaamFilter)
        Me.grpNieuweDeelname.Controls.Add(Me.cboNaamData)
        Me.grpNieuweDeelname.Controls.Add(Me.lblStudNaam)
        Me.grpNieuweDeelname.Location = New System.Drawing.Point(17, 51)
        Me.grpNieuweDeelname.Name = "grpNieuweDeelname"
        Me.grpNieuweDeelname.Size = New System.Drawing.Size(482, 89)
        Me.grpNieuweDeelname.TabIndex = 22
        Me.grpNieuweDeelname.TabStop = False
        Me.grpNieuweDeelname.Text = "Selecteer Student"
        '
        'pctGeldigeRekening
        '
        Me.pctGeldigeRekening.Image = Global.ADO_project.My.Resources.Resources.remove
        Me.pctGeldigeRekening.Location = New System.Drawing.Point(180, 198)
        Me.pctGeldigeRekening.Name = "pctGeldigeRekening"
        Me.pctGeldigeRekening.Size = New System.Drawing.Size(17, 14)
        Me.pctGeldigeRekening.TabIndex = 23
        Me.pctGeldigeRekening.TabStop = False
        '
        'lblGeldigeRekening
        '
        Me.lblGeldigeRekening.AutoSize = True
        Me.lblGeldigeRekening.ForeColor = System.Drawing.Color.Firebrick
        Me.lblGeldigeRekening.Location = New System.Drawing.Point(203, 198)
        Me.lblGeldigeRekening.Name = "lblGeldigeRekening"
        Me.lblGeldigeRekening.Size = New System.Drawing.Size(98, 13)
        Me.lblGeldigeRekening.TabIndex = 22
        Me.lblGeldigeRekening.Text = "Rekening Ongeldig"
        '
        'frmBeheerStudent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 527)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpStudentDetails)
        Me.Controls.Add(Me.grpNieuweDeelname)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBeheerStudent"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Studentenbeheer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.grpStudentDetails.ResumeLayout(False)
        Me.grpStudentDetails.PerformLayout()
        Me.grpNieuweDeelname.ResumeLayout(False)
        Me.grpNieuweDeelname.PerformLayout()
        CType(Me.pctGeldigeRekening, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents BeheerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DetailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtNaam As System.Windows.Forms.TextBox
    Friend WithEvents txtPriveMail As System.Windows.Forms.TextBox
    Friend WithEvents txtFinRek As System.Windows.Forms.TextBox
    Friend WithEvents txtSchoolMail As System.Windows.Forms.TextBox
    Friend WithEvents txtGSM As System.Windows.Forms.TextBox
    Friend WithEvents txtVoornaam As System.Windows.Forms.TextBox
    Friend WithEvents lblNaam As System.Windows.Forms.Label
    Friend WithEvents lblSchoolMail As System.Windows.Forms.Label
    Friend WithEvents lblFinRek As System.Windows.Forms.Label
    Friend WithEvents lblGebDat As System.Windows.Forms.Label
    Friend WithEvents lblPriveMail As System.Windows.Forms.Label
    Friend WithEvents lblGSM As System.Windows.Forms.Label
    Friend WithEvents lblVoornaam As System.Windows.Forms.Label
    Friend WithEvents btnStudentMail As System.Windows.Forms.Button
    Friend WithEvents dtpGebDat As System.Windows.Forms.DateTimePicker
    Friend WithEvents grpStudentDetails As System.Windows.Forms.GroupBox
    Friend WithEvents lblStudNaam As System.Windows.Forms.Label
    Friend WithEvents cboNaamData As System.Windows.Forms.ComboBox
    Friend WithEvents cboNaamFilter As System.Windows.Forms.ComboBox
    Friend WithEvents lblZoekenOp As System.Windows.Forms.Label
    Friend WithEvents grpNieuweDeelname As System.Windows.Forms.GroupBox
    Friend WithEvents pctGeldigeRekening As System.Windows.Forms.PictureBox
    Friend WithEvents lblGeldigeRekening As System.Windows.Forms.Label
End Class
