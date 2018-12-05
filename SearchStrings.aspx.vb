Public Class SearchStrings
    Inherits System.Web.UI.Page

    Dim _StringFoundCount As Integer

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If Not IsNothing(txtNameInput) Then
            GetNumOccurrences(txtNameInput.Text)
            MsgBox("The name " & txtNameInput.Text & " was found " & _StringFoundCount.ToString & " times.")
        Else
            MsgBox("Error: textbox is missing.")
        End If
    End Sub

    Private Sub GetNumOccurrences(_StringToFind)
        'First parse the first, middle, and last names, and middle initial, from the user-input name field
        Dim _split = _StringToFind.ToString.Split(" ")
        Dim _firstName = ""
        Dim _middleName = ""
        Dim _lastName = ""
        Dim _middleInitial = ""
        If _split.Length = 2 Then
            _firstName = _split(0)
            _lastName = _split(1)
        ElseIf _split.Length = 3 Then
            _firstName = _split(0)
            _middleName = _split(1)
            _lastName = _split(2)
            _middleInitial = _middleName.Substring(0, 1)
        Else
            MsgBox("Invalid Input. Please re-check formatting requirements and try again.")
            Exit Sub
        End If

        'Initialize variables
        _StringFoundCount = 0

        'Initialize a list of acceptable formats into the variable _listOfAccetableStrings, defined by the following rules.
        'The Application must find names Of the following formats, regardless of casing: 
        '[First Name] [Last Name]
        '[First Name] [Middle Initial] [Last Name]
        '[First Name] [Middle Initial]. [Last Name]
        '[First Name] [Middle Name] [Last Name]
        Dim _listOfAccetableStrings As New List(Of String)
        _listOfAccetableStrings.Add(_firstName & " " & _middleInitial & " " & _lastName)
        _listOfAccetableStrings.Add(_firstName & " " & _middleInitial & ". " & _lastName)
        _listOfAccetableStrings.Add(_firstName & " " & _lastName)
        _listOfAccetableStrings.Add(_firstName & " " & _middleName & " " & _lastName)

        'For each string in _listOfAccetableStrings, loop through every character in the text content field, 
        'And if the first character is a match, then check for a match based on the length of the current string.
        For Each _string In _listOfAccetableStrings
            Dim _length = _string.Length
            Dim _CharCounter As Integer = 0
            For Each _char As Char In txtContentToSearch.Text.ToString
                If _char = _StringToFind.ToString.Substring(0, 1) Then
                    Dim _StringOfSameLength = txtContentToSearch.Text.Substring(_CharCounter, _length)
                    If _StringOfSameLength.ToLower = _string.ToLower Then
                        _StringFoundCount = _StringFoundCount + 1
                    End If
                End If
                _CharCounter = _CharCounter + 1
            Next
        Next

    End Sub

End Class