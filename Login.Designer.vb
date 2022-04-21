<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnrestaurar = New System.Windows.Forms.Label()
        Me.btnacceder = New System.Windows.Forms.Button()
        Me.txtusuario = New System.Windows.Forms.TextBox()
        Me.txtcontraseña = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(271, 167)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Usuario"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(257, 219)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Contraseña"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnrestaurar
        '
        Me.btnrestaurar.AutoSize = True
        Me.btnrestaurar.BackColor = System.Drawing.Color.Transparent
        Me.btnrestaurar.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.btnrestaurar.ForeColor = System.Drawing.Color.Crimson
        Me.btnrestaurar.Location = New System.Drawing.Point(218, 281)
        Me.btnrestaurar.Name = "btnrestaurar"
        Me.btnrestaurar.Size = New System.Drawing.Size(170, 23)
        Me.btnrestaurar.TabIndex = 2
        Me.btnrestaurar.Text = "Olvide mi contraseña"
        Me.btnrestaurar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnacceder
        '
        Me.btnacceder.BackgroundImage = CType(resources.GetObject("btnacceder.BackgroundImage"), System.Drawing.Image)
        Me.btnacceder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnacceder.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.btnacceder.Location = New System.Drawing.Point(237, 316)
        Me.btnacceder.Name = "btnacceder"
        Me.btnacceder.Size = New System.Drawing.Size(127, 39)
        Me.btnacceder.TabIndex = 3
        Me.btnacceder.Text = "     Acceder"
        Me.btnacceder.UseVisualStyleBackColor = True
        '
        'txtusuario
        '
        Me.txtusuario.BackColor = System.Drawing.Color.MediumTurquoise
        Me.txtusuario.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.txtusuario.Location = New System.Drawing.Point(181, 193)
        Me.txtusuario.Name = "txtusuario"
        Me.txtusuario.PlaceholderText = "Ingrese su Nombre de Usuario"
        Me.txtusuario.Size = New System.Drawing.Size(233, 23)
        Me.txtusuario.TabIndex = 4
        Me.txtusuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtcontraseña
        '
        Me.txtcontraseña.BackColor = System.Drawing.Color.MediumTurquoise
        Me.txtcontraseña.Location = New System.Drawing.Point(181, 245)
        Me.txtcontraseña.Name = "txtcontraseña"
        Me.txtcontraseña.PlaceholderText = "Ingrese la Contraseña"
        Me.txtcontraseña.Size = New System.Drawing.Size(233, 23)
        Me.txtcontraseña.TabIndex = 5
        Me.txtcontraseña.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtcontraseña.UseSystemPasswordChar = True
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(598, 404)
        Me.Controls.Add(Me.txtcontraseña)
        Me.Controls.Add(Me.txtusuario)
        Me.Controls.Add(Me.btnacceder)
        Me.Controls.Add(Me.btnrestaurar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SISTEMA BIBLIOTECA"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnrestaurar As Label
    Friend WithEvents btnacceder As Button
    Friend WithEvents txtusuario As TextBox
    Friend WithEvents txtcontraseña As TextBox
End Class
