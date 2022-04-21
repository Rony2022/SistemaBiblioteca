<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Recuperacion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Recuperacion))
        Me.btnacceder = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnacceder
        '
        Me.btnacceder.BackgroundImage = CType(resources.GetObject("btnacceder.BackgroundImage"), System.Drawing.Image)
        Me.btnacceder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnacceder.Location = New System.Drawing.Point(245, 318)
        Me.btnacceder.Name = "btnacceder"
        Me.btnacceder.Size = New System.Drawing.Size(116, 38)
        Me.btnacceder.TabIndex = 0
        Me.btnacceder.Text = "Acceder"
        Me.btnacceder.UseVisualStyleBackColor = True
        '
        'Recuperacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(597, 399)
        Me.Controls.Add(Me.btnacceder)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Recuperacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recuperacion"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnacceder As Button
End Class
