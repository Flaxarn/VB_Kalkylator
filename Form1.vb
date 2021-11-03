Public Class Form1
    'Globala variabler
    Dim tal1 As Single ' tal 1
    Dim tal2 As Single ' tal 2
    Dim resultat As Single ' resultat

    Dim [operator] As Integer ' val av räknesätt för case
    Dim negativt As Boolean ' för kolla av negativa nummer

    Private Sub TxtInput_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtInput.KeyPress
        'GÄLLER ENDAST INPUT MED TBORD
        'Tillåta siffror, backspace och.
        If (e.KeyChar < "0"c Or e.KeyChar > "9"c) And e.KeyChar <> vbBack And e.KeyChar <> "."c Then
            e.Handled = True
        End If

        'Hantera extra . // OBS BLIR FEL MED FLERA NUMMER (ej tbord )
        If e.KeyChar = "."c And InStr(sender.text, "."c) > 0 Then
            e.Handled = True
        End If

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

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        'User slected the add button
        [operator] = 1
        'Convert into a number and transfer the value from
        'The text box on the form into the first number

        tal1 = Val(TxtInput.Text)


        TxtInput.Text = ""
    End Sub

    Private Sub BtnSub_Click(sender As Object, e As EventArgs) Handles BtnSub.Click
        [operator] = 2
        'Convert into a number and transfer the value from
        'The text box on the form into the first number
        tal1 = Val(TxtInput.Text)
        TxtInput.Text = ""
    End Sub

    Private Sub BtnDivide_Click(sender As Object, e As EventArgs) Handles BtnDivide.Click
        'User slected the Divide button
        [operator] = 4
        'Convert into a number and transfer the value from
        'The text box on the form into the first number
        tal1 = Val(TxtInput.Text)

        TxtInput.Text = ""
    End Sub

    Private Sub BtnMultiplie_Click(sender As Object, e As EventArgs) Handles BtnMultiplie.Click
        'User slected the multiply button
        [operator] = 3
        'Convert into a number and transfer the value from
        'The text box on the form into the first number
        tal1 = Val(TxtInput.Text)

        TxtInput.Text = ""
    End Sub

    Private Sub Btn1_Click(sender As Object, e As EventArgs) Handles Btn1.Click
        TxtInput.Text = TxtInput.Text & "1"
    End Sub

    Private Sub Btn2_Click(sender As Object, e As EventArgs) Handles Btn2.Click
        TxtInput.Text = TxtInput.Text & "2"
    End Sub

    Private Sub Btn3_Click(sender As Object, e As EventArgs) Handles Btn3.Click
        TxtInput.Text = TxtInput.Text & "3"
    End Sub

    Private Sub Btn4_Click(sender As Object, e As EventArgs) Handles Btn4.Click
        TxtInput.Text = TxtInput.Text & "4"
    End Sub

    Private Sub Btn5_Click(sender As Object, e As EventArgs) Handles Btn5.Click
        TxtInput.Text = TxtInput.Text & "5"
    End Sub

    Private Sub Btn6_Click(sender As Object, e As EventArgs) Handles Btn6.Click
        TxtInput.Text = TxtInput.Text & "6"
    End Sub

    Private Sub Btn7_Click(sender As Object, e As EventArgs) Handles Btn7.Click
        TxtInput.Text = TxtInput.Text & "7"
    End Sub

    Private Sub Btn8_Click(sender As Object, e As EventArgs) Handles Btn8.Click
        TxtInput.Text = TxtInput.Text & "8"
    End Sub

    Private Sub Btn9_Click(sender As Object, e As EventArgs) Handles Btn9.Click
        TxtInput.Text = TxtInput.Text & "9"
    End Sub

    Private Sub Btn0_Click(sender As Object, e As EventArgs) Handles Btn0.Click
        TxtInput.Text = TxtInput.Text & "0"
    End Sub

    Private Sub BtnDot_Click(sender As Object, e As EventArgs) Handles BtnDot.Click
        If InStr(TxtInput.Text, "."c) = 0 Then
            TxtInput.Text = TxtInput.Text & "."
        End If

        If InStr(TxtInput.Text, "."c) > 0 Then
            ' här ska vi ta bort decimal om det redan finns en...

        End If
    End Sub

    Private Sub BtnAC_Click(sender As Object, e As EventArgs) Handles BtnAC.Click
        [operator] = 0
        tal1 = 0
        tal2 = 0
        TxtInput.Text = ""
        resultat = Nothing
    End Sub

    Private Sub BtnSum_Click(sender As Object, e As EventArgs) Handles BtnSum.Click
        tal2 = Val(TxtInput.Text)

        Select Case [operator]
            Case Is = 1
                resultat = tal1 + tal2
            Case Is = 2
                resultat = tal1 - tal2
            Case Is = 3
                resultat = tal1 * tal2
            Case Is = 4
                resultat = tal1 / tal2
        End Select
        TxtInput.Text = resultat
    End Sub

    Private Sub BtnChange_Click(sender As Object, e As EventArgs) Handles BtnChange.Click
        Dim MINUSVALUE
        'Sign state = false on load of form
        If TxtInput.Text = "-" & TxtInput.Text Then
            MsgBox("error start again")
        End If
        If negativt = False Then
            TxtInput.Text = "-" & TxtInput.Text
            negativt = True
        Else
            'SignState = True

            MINUSVALUE = Val(TxtInput.Text)
            'Value now positive
            MINUSVALUE = Val("-1" * MINUSVALUE)
            TxtInput.Text = MINUSVALUE
            negativt = False
        End If
    End Sub

    Private Sub BtnC_Click(sender As Object, e As EventArgs) Handles BtnC.Click
        TxtInput.Text = ""
    End Sub
End Class
