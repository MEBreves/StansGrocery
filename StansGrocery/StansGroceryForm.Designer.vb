<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StansGroceryForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TopMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchMenuToolStripItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitMenuToolStripItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutMenuToolStripItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SearchContextToolStripItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitContextToolStripItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.FilterGroupBox = New System.Windows.Forms.GroupBox()
        Me.FilterByCategoryRadioButton = New System.Windows.Forms.RadioButton()
        Me.FilterByAisleRadioButton = New System.Windows.Forms.RadioButton()
        Me.SearchButton = New System.Windows.Forms.Button()
        Me.SearchTextBox = New System.Windows.Forms.TextBox()
        Me.SearchLabel = New System.Windows.Forms.Label()
        Me.FilterComboBox = New System.Windows.Forms.ComboBox()
        Me.FilterLabel = New System.Windows.Forms.Label()
        Me.DisplayListBox = New System.Windows.Forms.ListBox()
        Me.DisplayLabel = New System.Windows.Forms.Label()
        Me.AvailableItemsLabel = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TopMenuStrip.SuspendLayout()
        Me.ContextMenuStrip.SuspendLayout()
        Me.FilterGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'TopMenuStrip
        '
        Me.TopMenuStrip.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.TopMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.TopMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.TopMenuStrip.Name = "TopMenuStrip"
        Me.TopMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.TopMenuStrip.Size = New System.Drawing.Size(745, 40)
        Me.TopMenuStrip.TabIndex = 0
        Me.TopMenuStrip.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SearchMenuToolStripItem, Me.ExitMenuToolStripItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(71, 36)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SearchMenuToolStripItem
        '
        Me.SearchMenuToolStripItem.Name = "SearchMenuToolStripItem"
        Me.SearchMenuToolStripItem.Size = New System.Drawing.Size(218, 44)
        Me.SearchMenuToolStripItem.Text = "&Search"
        '
        'ExitMenuToolStripItem
        '
        Me.ExitMenuToolStripItem.Name = "ExitMenuToolStripItem"
        Me.ExitMenuToolStripItem.Size = New System.Drawing.Size(218, 44)
        Me.ExitMenuToolStripItem.Text = "E&xit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutMenuToolStripItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(84, 36)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutMenuToolStripItem
        '
        Me.AboutMenuToolStripItem.Name = "AboutMenuToolStripItem"
        Me.AboutMenuToolStripItem.Size = New System.Drawing.Size(212, 44)
        Me.AboutMenuToolStripItem.Text = "&About"
        '
        'ContextMenuStrip
        '
        Me.ContextMenuStrip.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SearchContextToolStripItem, Me.ExitContextToolStripItem})
        Me.ContextMenuStrip.Name = "ContextMenuStrip"
        Me.ContextMenuStrip.Size = New System.Drawing.Size(160, 80)
        '
        'SearchContextToolStripItem
        '
        Me.SearchContextToolStripItem.Name = "SearchContextToolStripItem"
        Me.SearchContextToolStripItem.Size = New System.Drawing.Size(159, 38)
        Me.SearchContextToolStripItem.Text = "&Search"
        '
        'ExitContextToolStripItem
        '
        Me.ExitContextToolStripItem.Name = "ExitContextToolStripItem"
        Me.ExitContextToolStripItem.Size = New System.Drawing.Size(159, 38)
        Me.ExitContextToolStripItem.Text = "E&xit"
        '
        'FilterGroupBox
        '
        Me.FilterGroupBox.Controls.Add(Me.FilterByCategoryRadioButton)
        Me.FilterGroupBox.Controls.Add(Me.FilterByAisleRadioButton)
        Me.FilterGroupBox.Location = New System.Drawing.Point(23, 168)
        Me.FilterGroupBox.Name = "FilterGroupBox"
        Me.FilterGroupBox.Size = New System.Drawing.Size(235, 142)
        Me.FilterGroupBox.TabIndex = 2
        Me.FilterGroupBox.TabStop = False
        Me.FilterGroupBox.Text = "Filter"
        '
        'FilterByCategoryRadioButton
        '
        Me.FilterByCategoryRadioButton.AutoSize = True
        Me.FilterByCategoryRadioButton.Location = New System.Drawing.Point(28, 86)
        Me.FilterByCategoryRadioButton.Name = "FilterByCategoryRadioButton"
        Me.FilterByCategoryRadioButton.Size = New System.Drawing.Size(174, 36)
        Me.FilterByCategoryRadioButton.TabIndex = 3
        Me.FilterByCategoryRadioButton.TabStop = True
        Me.FilterByCategoryRadioButton.Text = "By Category"
        Me.FilterByCategoryRadioButton.UseVisualStyleBackColor = True
        '
        'FilterByAisleRadioButton
        '
        Me.FilterByAisleRadioButton.AutoSize = True
        Me.FilterByAisleRadioButton.Location = New System.Drawing.Point(28, 44)
        Me.FilterByAisleRadioButton.Name = "FilterByAisleRadioButton"
        Me.FilterByAisleRadioButton.Size = New System.Drawing.Size(128, 36)
        Me.FilterByAisleRadioButton.TabIndex = 2
        Me.FilterByAisleRadioButton.TabStop = True
        Me.FilterByAisleRadioButton.Text = "By Aisle"
        Me.FilterByAisleRadioButton.UseVisualStyleBackColor = True
        '
        'SearchButton
        '
        Me.SearchButton.BackColor = System.Drawing.Color.YellowGreen
        Me.SearchButton.Location = New System.Drawing.Point(556, 100)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(150, 46)
        Me.SearchButton.TabIndex = 1
        Me.SearchButton.Text = "Search"
        Me.SearchButton.UseVisualStyleBackColor = False
        '
        'SearchTextBox
        '
        Me.SearchTextBox.Location = New System.Drawing.Point(23, 102)
        Me.SearchTextBox.Name = "SearchTextBox"
        Me.SearchTextBox.Size = New System.Drawing.Size(500, 39)
        Me.SearchTextBox.TabIndex = 0
        '
        'SearchLabel
        '
        Me.SearchLabel.AutoSize = True
        Me.SearchLabel.CausesValidation = False
        Me.SearchLabel.Location = New System.Drawing.Point(21, 60)
        Me.SearchLabel.Name = "SearchLabel"
        Me.SearchLabel.Size = New System.Drawing.Size(150, 32)
        Me.SearchLabel.TabIndex = 5
        Me.SearchLabel.Text = "Search Items"
        '
        'FilterComboBox
        '
        Me.FilterComboBox.FormattingEnabled = True
        Me.FilterComboBox.Location = New System.Drawing.Point(310, 203)
        Me.FilterComboBox.Name = "FilterComboBox"
        Me.FilterComboBox.Size = New System.Drawing.Size(407, 40)
        Me.FilterComboBox.TabIndex = 4
        '
        'FilterLabel
        '
        Me.FilterLabel.AutoSize = True
        Me.FilterLabel.Location = New System.Drawing.Point(310, 168)
        Me.FilterLabel.Name = "FilterLabel"
        Me.FilterLabel.Size = New System.Drawing.Size(166, 32)
        Me.FilterLabel.TabIndex = 7
        Me.FilterLabel.Text = "Filter Keyword"
        '
        'DisplayListBox
        '
        Me.DisplayListBox.FormattingEnabled = True
        Me.DisplayListBox.ItemHeight = 32
        Me.DisplayListBox.Location = New System.Drawing.Point(23, 362)
        Me.DisplayListBox.Name = "DisplayListBox"
        Me.DisplayListBox.Size = New System.Drawing.Size(367, 260)
        Me.DisplayListBox.TabIndex = 5
        '
        'DisplayLabel
        '
        Me.DisplayLabel.BackColor = System.Drawing.Color.YellowGreen
        Me.DisplayLabel.Location = New System.Drawing.Point(417, 362)
        Me.DisplayLabel.MinimumSize = New System.Drawing.Size(300, 260)
        Me.DisplayLabel.Name = "DisplayLabel"
        Me.DisplayLabel.Size = New System.Drawing.Size(300, 260)
        Me.DisplayLabel.TabIndex = 9
        Me.DisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AvailableItemsLabel
        '
        Me.AvailableItemsLabel.AutoSize = True
        Me.AvailableItemsLabel.Location = New System.Drawing.Point(21, 327)
        Me.AvailableItemsLabel.Name = "AvailableItemsLabel"
        Me.AvailableItemsLabel.Size = New System.Drawing.Size(175, 32)
        Me.AvailableItemsLabel.TabIndex = 10
        Me.AvailableItemsLabel.Text = "Available Items"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'StansGroceryForm
        '
        Me.AcceptButton = Me.SearchButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 32.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(745, 644)
        Me.Controls.Add(Me.DisplayLabel)
        Me.Controls.Add(Me.DisplayListBox)
        Me.Controls.Add(Me.AvailableItemsLabel)
        Me.Controls.Add(Me.SearchTextBox)
        Me.Controls.Add(Me.FilterComboBox)
        Me.Controls.Add(Me.FilterLabel)
        Me.Controls.Add(Me.SearchLabel)
        Me.Controls.Add(Me.SearchButton)
        Me.Controls.Add(Me.FilterGroupBox)
        Me.Controls.Add(Me.TopMenuStrip)
        Me.MainMenuStrip = Me.TopMenuStrip
        Me.Name = "StansGroceryForm"
        Me.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stan's Grocery App"
        Me.TopMenuStrip.ResumeLayout(False)
        Me.TopMenuStrip.PerformLayout()
        Me.ContextMenuStrip.ResumeLayout(False)
        Me.FilterGroupBox.ResumeLayout(False)
        Me.FilterGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TopMenuStrip As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SearchMenuToolStripItem As ToolStripMenuItem
    Friend WithEvents ExitMenuToolStripItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutMenuToolStripItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip As ContextMenuStrip
    Friend WithEvents SearchContextToolStripItem As ToolStripMenuItem
    Friend WithEvents ExitContextToolStripItem As ToolStripMenuItem
    Friend WithEvents MainToolTip As ToolTip
    Friend WithEvents FilterGroupBox As GroupBox
    Friend WithEvents FilterByCategoryRadioButton As RadioButton
    Friend WithEvents FilterByAisleRadioButton As RadioButton
    Friend WithEvents SearchButton As Button
    Friend WithEvents SearchTextBox As TextBox
    Friend WithEvents SearchLabel As Label
    Friend WithEvents FilterComboBox As ComboBox
    Friend WithEvents FilterLabel As Label
    Friend WithEvents DisplayListBox As ListBox
    Friend WithEvents DisplayLabel As Label
    Friend WithEvents AvailableItemsLabel As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
