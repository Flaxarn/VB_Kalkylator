Public Class Form1
    'Globala variabler
    Dim assign_input As Double = 0  ' Hållare av input
    Dim operation As String         ' operation för = case
    Dim found_expression As Boolean = False ' Koll för om räknesätt

    Private Sub BtnC_Click(sender As Object, e As EventArgs) Handles BtnC.Click
        ' rensa input box
        TxtInput.Text = "0"
    End Sub

    Private Sub BtnAC_Click(sender As Object, e As EventArgs) Handles BtnAC.Click
        ' rensa alla variabler o boxar
        TxtInput.Text = "0"
        lblExpression.Text = ""
        found_expression = False
        assign_input = 0
    End Sub

    ' Hantera alla nummer klick
    Private Sub num_Click(sender As Object, e As EventArgs) Handles Btn9.Click, Btn8.Click, Btn7.Click, Btn6.Click, Btn5.Click, Btn4.Click, Btn3.Click, Btn2.Click, Btn1.Click, Btn0.Click
        Dim b As Button = sender
        If ((TxtInput.Text = "0") Or (found_expression)) Then
            TxtInput.Clear()
            TxtInput.Text = b.Text
            found_expression = False
        ElseIf (b.Text = ".") Then

            If (Not TxtInput.Text.Contains(".")) Then
                TxtInput.Text = TxtInput.Text + b.Text
            End If
        Else
            TxtInput.Text = TxtInput.Text + b.Text
        End If
    End Sub

    Private Sub operation_Click(sender As Object, e As EventArgs) Handles BtnSub.Click, BtnMultiplie.Click, BtnDivide.Click, BtnAdd.Click
        ' Hantera alla operator click
        Dim b As Button = sender
        If (assign_input <> 0) Then
            BtnSum.PerformClick()
            found_expression = True
            operation = b.Text
            lblExpression.Text = assign_input & "   " & operation
        Else
            operation = b.Text
            assign_input = Double.Parse(TxtInput.Text)
            found_expression = True
            lblExpression.Text = assign_input & "   " & operation
        End If
    End Sub


    Private Sub BtnSum_Click(sender As Object, e As EventArgs) Handles BtnSum.Click
        ' Case för operator vid summa
        lblExpression.Text = ""
        Select Case operation
            Case "+"
                TxtInput.Text = (assign_input + Double.Parse(TxtInput.Text)).ToString()
            Case "-"
                TxtInput.Text = (assign_input - Double.Parse(TxtInput.Text)).ToString()
            Case "/"
                TxtInput.Text = (assign_input / Double.Parse(TxtInput.Text)).ToString()
            Case "*"
                TxtInput.Text = (assign_input * Double.Parse(TxtInput.Text)).ToString()
        End Select

        assign_input = Double.Parse(TxtInput.Text)
        operation = ""
    End Sub

    ' Lägg till / ta bort decimal
    Private Sub BtnDot_Click(sender As Object, e As EventArgs) Handles BtnDot.Click
        If InStr(TxtInput.Text, ","c) = 0 Then
            TxtInput.Text = TxtInput.Text & ","
        End If

        If InStr(TxtInput.Text, ","c) > 0 Then
            ' här ska vi ta bort decimal om det redan finns en...

        End If
    End Sub

    ' Ändra från och till negativt tal
    Private Sub BtnChange_Click(sender As Object, e As EventArgs) Handles BtnChange.Click
        If TxtInput.Text.StartsWith("-"c) Then
            TxtInput.Text = Mid(TxtInput.Text, 2)
        Else
            TxtInput.Text = "-" & TxtInput.Text
        End If
        TxtInput.Select(TxtInput.Text.Length, 0)
    End Sub

    ' Hantering av tangetbord
    Private Sub TxtInput_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtInput.KeyPress
        'GÄLLER ENDAST INPUT MED TBORD
        'Tillåta siffror, backspace och.
        If (e.KeyChar < "0"c Or e.KeyChar > "9"c) And e.KeyChar <> vbBack And e.KeyChar <> "."c Then
            e.Handled = True
        End If

        'Hantera extra . // OBS FUNKAR EJ . skall vara , 
        'If e.KeyChar = "."c And InStr(sender.text, "."c) > 0 Then
        'e.Handled = True
        'End If

        'Hantera - tecken // OBS BLIR FEL MED FLERA NUMMER ( ej tbord )
        If e.KeyChar = "-"c Then
            If sender.Text.Startswith("-"c) Then
                sender.Text = Mid(sender.Text, 2)
            Else
                sender.text = "-" & sender.text
            End If
            sender.select(sender.text.length, 0)
        End If

    End Sub



End Class
