<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Deelname
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
        Me.DetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cboDeelnameStudent = New System.Windows.Forms.ComboBox
        Me.lblDeelnameStudent = New System.Windows.Forms.Label
        Me.cboDeelnameSport = New System.Windows.Forms.ComboBox
        Me.lblDeelnameSport = New System.Windows.Forms.Label
        Me.txtNiveau = New System.Windows.Forms.TextBox
        Me.lblNiveau = New System.Windows.Forms.Label
        Me.cboNiveau = New System.Windows.Forms.ComboBox
        Me.lblNiveauCombo = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BeheerToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(284, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'BeheerToolStripMenuItem
        '
        Me.BeheerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DetailsToolStripMenuItem, Me.NewToolStripMenuItem, Me.EditToolStripMenuItem, Me.SaveToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.CancelToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.BeheerToolStripMenuItem.Name = "BeheerToolStripMenuItem"
        Me.BeheerToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.BeheerToolStripMenuItem.Text = "Beheer"
        '
        'DetailsToolStripMenuItem
        '
        Me.DetailsToolStripMenuItem.Name = "DetailsToolStripMenuItem"
        Me.DetailsToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.DetailsToolStripMenuItem.Text = "Details"
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
        'cboDeelnameStudent
        '
        Me.cboDeelnameStudent.FormattingEnabled = True
        Me.cboDeelnameStudent.Location = New System.Drawing.Point(151, 45)
        Me.cboDeelnameStudent.Name = "cboDeelnameStudent"
        Me.cboDeelnameStudent.Size = New System.Drawing.Size(121, 21)
        Me.cboDeelnameStudent.TabIndex = 1
        '
        'lblDeelnameStudent
        '
        Me.lblDeelnameStudent.AutoSize = True
        Me.lblDeelnameStudent.Location = New System.Drawing.Point(13, 45)
        Me.lblDeelnameStudent.Name = "lblDeelnameStudent"
        Me.lblDeelnameStudent.Size = New System.Drawing.Size(44, 13)
        Me.lblDeelnameStudent.TabIndex = 2
        Me.lblDeelnameStudent.Text = "Student"
        '
        'cboDeelnameSport
        '
        Me.cboDeelnameSport.FormattingEnabled = True
        Me.cboDeelnameSport.Location = New System.Drawing.Point(151, 91)
        Me.cboDeelnameSport.Name = "cboDeelnameSport"
        Me.cboDeelnameSport.Size = New System.Drawing.Size(121, 21)
        Me.cboDeelnameSport.TabIndex = 3
        '
        'lblDeelnameSport
        '
        Me.lblDeelnameSport.AutoSize = True
        Me.lblDeelnameSport.Location = New System.Drawing.Point(13, 91)
        Me.lblDeelnameSport.Name = "lblDeelnameSport"
        Me.lblDeelnameSport.Size = New System.Drawing.Size(32, 13)
        Me.lblDeelnameSport.TabIndex = 4
        Me.lblDeelnameSport.Text = "Sport"
        '
        'txtNiveau
        '
        Me.txtNiveau.Location = New System.Drawing.Point(151, 213)
        Me.txtNiveau.Name = "txtNiveau"
        Me.txtNiveau.Size = New System.Drawing.Size(100, 20)
        Me.txtNiveau.TabIndex = 5
        '
        'lblNiveau
        '
        Me.lblNiveau.AutoSize = True
        Me.lblNiveau.Location = New System.Drawing.Point(16, 213)
        Me.lblNiveau.Name = "lblNiveau"
        Me.lblNiveau.Size = New System.Drawing.Size(74, 13)
        Me.lblNiveau.TabIndex = 6
        Me.lblNiveau.Text = "Nieuw Niveau"
        '
        'cboNiveau
        '
        Me.cboNiveau.FormattingEnabled = True
        Me.cboNiveau.Location = New System.Drawing.Point(151, 142)
        Me.cboNiveau.Name = "cboNiveau"
        Me.cboNiveau.Size = New System.Drawing.Size(121, 21)
        Me.cboNiveau.TabIndex = 7
        '
        'lblNiveauCombo
        '
        Me.lblNiveauCombo.AutoSize = True
        Me.lblNiveauCombo.Location = New System.Drawing.Point(16, 142)
        Me.lblNiveauCombo.Name = "lblNiveauCombo"
        Me.lblNiveauCombo.Size = New System.Drawing.Size(41, 13)
        Me.lblNiveauCombo.TabIndex = 8
        Me.lblNiveauCombo.Text = "Niveau"
        '
        'Deelname
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 264)
        Me.Controls.Add(Me.lblNiveauCombo)
        Me.Controls.Add(Me.cboNiveau)
        Me.Controls.Add(Me.lblNiveau)
        Me.Controls.Add(Me.txtNiveau)
        Me.Controls.Add(Me.lblDeelnameSport)
        Me.Controls.Add(Me.cboDeelnameSport)
        Me.Controls.Add(Me.lblDeelnameStudent)
        Me.Controls.Add(Me.cboDeelnameStudent)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Deelname"
        Me.Text = "Deelname"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents BeheerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboDeelnameStudent As System.Windows.Forms.ComboBox
    Friend WithEvents lblDeelnameStudent As System.Windows.Forms.Label
    Friend WithEvents cboDeelnameSport As System.Windows.Forms.ComboBox
    Friend WithEvents lblDeelnameSport As System.Windows.Forms.Label
    Friend WithEvents txtNiveau As System.Windows.Forms.TextBox
    Friend WithEvents lblNiveau As System.Windows.Forms.Label
    Friend WithEvents cboNiveau As System.Windows.Forms.ComboBox
    Friend WithEvents lblNiveauCombo As System.Windows.Forms.Label
End Class
