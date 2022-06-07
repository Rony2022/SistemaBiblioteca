<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Principal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.PaisesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaisesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CategoriasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditorialesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LibrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LibrosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GestionDeUsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrestamosYDevolucionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Bookman Old Style", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1346, 116)
        Me.Label1.TabIndex = 0
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Panel1
        '
        Me.Panel1.AccessibleName = ""
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Bookman Old Style", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Panel1.Location = New System.Drawing.Point(0, 151)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1346, 530)
        Me.Panel1.TabIndex = 3
        Me.Panel1.Tag = ""
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 35)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.AutoSize = False
        Me.ToolStripButton4.BackColor = System.Drawing.Color.Black
        Me.ToolStripButton4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PaisesToolStripMenuItem1, Me.PaisesToolStripMenuItem, Me.CategoriasToolStripMenuItem, Me.EditorialesToolStripMenuItem, Me.LibrosToolStripMenuItem, Me.LibrosToolStripMenuItem1, Me.GestionDeUsuariosToolStripMenuItem, Me.PrestamosYDevolucionesToolStripMenuItem})
        Me.ToolStripButton4.Font = New System.Drawing.Font("Baskerville Old Face", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.ToolStripButton4.ForeColor = System.Drawing.Color.Turquoise
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Margin = New System.Windows.Forms.Padding(1)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(143, 33)
        Me.ToolStripButton4.Text = "Opciones"
        '
        'PaisesToolStripMenuItem1
        '
        Me.PaisesToolStripMenuItem1.BackColor = System.Drawing.Color.Black
        Me.PaisesToolStripMenuItem1.ForeColor = System.Drawing.Color.PaleTurquoise
        Me.PaisesToolStripMenuItem1.Image = CType(resources.GetObject("PaisesToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.PaisesToolStripMenuItem1.Name = "PaisesToolStripMenuItem1"
        Me.PaisesToolStripMenuItem1.Size = New System.Drawing.Size(267, 22)
        Me.PaisesToolStripMenuItem1.Text = "Paises"
        '
        'PaisesToolStripMenuItem
        '
        Me.PaisesToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.PaisesToolStripMenuItem.ForeColor = System.Drawing.Color.PaleTurquoise
        Me.PaisesToolStripMenuItem.Image = CType(resources.GetObject("PaisesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PaisesToolStripMenuItem.Name = "PaisesToolStripMenuItem"
        Me.PaisesToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.PaisesToolStripMenuItem.Text = "Idiomas"
        '
        'CategoriasToolStripMenuItem
        '
        Me.CategoriasToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.CategoriasToolStripMenuItem.ForeColor = System.Drawing.Color.PaleTurquoise
        Me.CategoriasToolStripMenuItem.Image = CType(resources.GetObject("CategoriasToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CategoriasToolStripMenuItem.Name = "CategoriasToolStripMenuItem"
        Me.CategoriasToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.CategoriasToolStripMenuItem.Text = "Categorias"
        '
        'EditorialesToolStripMenuItem
        '
        Me.EditorialesToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.EditorialesToolStripMenuItem.ForeColor = System.Drawing.Color.PaleTurquoise
        Me.EditorialesToolStripMenuItem.Image = CType(resources.GetObject("EditorialesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditorialesToolStripMenuItem.Name = "EditorialesToolStripMenuItem"
        Me.EditorialesToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.EditorialesToolStripMenuItem.Text = "Editoriales"
        '
        'LibrosToolStripMenuItem
        '
        Me.LibrosToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.LibrosToolStripMenuItem.ForeColor = System.Drawing.Color.PaleTurquoise
        Me.LibrosToolStripMenuItem.Image = CType(resources.GetObject("LibrosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LibrosToolStripMenuItem.Name = "LibrosToolStripMenuItem"
        Me.LibrosToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.LibrosToolStripMenuItem.Text = "Autores"
        '
        'LibrosToolStripMenuItem1
        '
        Me.LibrosToolStripMenuItem1.BackColor = System.Drawing.Color.Black
        Me.LibrosToolStripMenuItem1.ForeColor = System.Drawing.Color.PaleTurquoise
        Me.LibrosToolStripMenuItem1.Image = CType(resources.GetObject("LibrosToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.LibrosToolStripMenuItem1.Name = "LibrosToolStripMenuItem1"
        Me.LibrosToolStripMenuItem1.Size = New System.Drawing.Size(267, 22)
        Me.LibrosToolStripMenuItem1.Text = "Libros"
        '
        'GestionDeUsuariosToolStripMenuItem
        '
        Me.GestionDeUsuariosToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.GestionDeUsuariosToolStripMenuItem.ForeColor = System.Drawing.Color.PaleTurquoise
        Me.GestionDeUsuariosToolStripMenuItem.Image = CType(resources.GetObject("GestionDeUsuariosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GestionDeUsuariosToolStripMenuItem.Name = "GestionDeUsuariosToolStripMenuItem"
        Me.GestionDeUsuariosToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.GestionDeUsuariosToolStripMenuItem.Text = "Gestion de Usuarios"
        '
        'PrestamosYDevolucionesToolStripMenuItem
        '
        Me.PrestamosYDevolucionesToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.PrestamosYDevolucionesToolStripMenuItem.ForeColor = System.Drawing.Color.PaleTurquoise
        Me.PrestamosYDevolucionesToolStripMenuItem.Image = CType(resources.GetObject("PrestamosYDevolucionesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrestamosYDevolucionesToolStripMenuItem.Name = "PrestamosYDevolucionesToolStripMenuItem"
        Me.PrestamosYDevolucionesToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.PrestamosYDevolucionesToolStripMenuItem.Text = "Prestamos y Devoluciones"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 35)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.Black
        Me.ToolStrip1.Font = New System.Drawing.Font("Monotype Corsiva", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.ToolStripSeparator1, Me.ToolStripButton4, Me.ToolStripSeparator6})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 116)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1346, 35)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.AutoSize = False
        Me.ToolStripDropDownButton1.BackColor = System.Drawing.Color.Black
        Me.ToolStripDropDownButton1.Font = New System.Drawing.Font("Baskerville Old Face", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.ToolStripDropDownButton1.ForeColor = System.Drawing.Color.Turquoise
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Margin = New System.Windows.Forms.Padding(1)
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(143, 33)
        Me.ToolStripDropDownButton1.Text = " Inicio"
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1346, 681)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1400, 720)
        Me.Name = "Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SISTEMA BIBLIOTECA"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripButton4 As ToolStripDropDownButton
    Friend WithEvents PaisesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CategoriasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditorialesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LibrosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents LibrosToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents PaisesToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents GestionDeUsuariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrestamosYDevolucionesToolStripMenuItem As ToolStripMenuItem
End Class
