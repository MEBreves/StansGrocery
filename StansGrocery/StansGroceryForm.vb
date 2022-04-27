'Miranda Breves
'RCET0265
'Spring 2022
'Stan's Grocery App
'github url

Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Text.RegularExpressions

Public Class StansGroceryForm

    'Declaring global variables
    Dim food(,) As String
    Dim filterComboBoxAisleItems() As String = New String() _
                    {"Show All", "Aisle 1", "Aisle 2", "Aisle 3", "Aisle 4", "Aisle 5", "Aisle 6", "Aisle 7", "Aisle 8",
                     "Aisle 9", "Aisle 10", "Aisle 11", "Aisle 12", "Aisle 13", "Aisle 14", "Aisle 15"}

    Dim filterComboBoxCategoryItems() As String = New String() _
                    {"Fresh Vegetables", "Fresh Fruit", "Frozen", "Condiments / Sauces", "Various groceries", "Canned foods",
                     "Spices & herbs", "Dairy", "Cheese", "Meat", "Seafood", "Beverages", "Baked goods", "Baking", "Snacks",
                     "Themed meals", "Baby stuff", "Pets", "Personal care", "Pharmacy", "Kitchen", "Cleaning products",
                     "Office supplies", "Other stuff"}

    Private Sub StansGroceryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Declaring variables
        Dim sortingList As List(Of String)

        Me.BackColor = ColorTranslator.FromWin32(RGB(71, 168, 49))
        TopMenuStrip.BackColor = ColorTranslator.FromWin32(RGB(41, 110, 25))
        TopMenuStrip.ForeColor = Color.White

        LoadGroceryItems()

        'Set defaults for all controls
        FilterByAisleRadioButton.Checked = True
        FilterByCategoryRadioButton.Checked = False

        FilterComboBox.Items.AddRange(filterComboBoxAisleItems)
        FilterComboBox.SelectedItem = FilterComboBox.Items.Item(0)

        'Sort filter combo box category items alphabetically
        sortingList = filterComboBoxCategoryItems.ToList()
        sortingList.Sort()
        sortingList.Insert(0, "Show All")
        filterComboBoxCategoryItems = sortingList.ToArray()

        'Add items to the display box
        For i As Integer = 0 To CInt(food.Length / 3) - 1
            DisplayListBox.Items.Add(food(i, 0))
        Next

    End Sub


    ' ===========================================  Form Object Handling  =================================================

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click,
        SearchContextToolStripItem.Click, SearchMenuToolStripItem.Click

        'Declaring variables
        Dim stringSpacePattern As String = "^[A-Za-z\s]+$"
        Dim regex As Regex = New Regex(stringSpacePattern)

        If SearchTextBox.Text = "zzz" Then

            'Immediately exit program
            Me.Close()

        Else
            'Radio buttons and filter combo box go to default
            FilterByAisleRadioButton.Checked = True
            FilterByCategoryRadioButton.Checked = False

            FilterComboBox.Items.Clear()
            FilterComboBox.Items.AddRange(filterComboBoxAisleItems)
            FilterComboBox.SelectedItem = FilterComboBox.Items.Item(0)

            'Searchbox.txt is evaluated
            If Not regex.IsMatch(SearchTextBox.Text) Then
                MsgBox("The name of the items you were trying to find was invalid. Please search for an item without using " &
                       "numbers.", , "Search Error")
                Exit Sub
            End If

            FilterItems()

        End If

    End Sub

    Private Sub FilterRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles _
            FilterByAisleRadioButton.CheckedChanged, FilterByCategoryRadioButton.CheckedChanged

        FilterComboBox.Items.Clear()

        Select Case True
            Case FilterByAisleRadioButton.Checked
                FilterComboBox.Items.AddRange(filterComboBoxAisleItems)
            Case FilterByCategoryRadioButton.Checked
                FilterComboBox.Items.AddRange(filterComboBoxCategoryItems)
        End Select

        FilterComboBox.SelectedItem = FilterComboBox.Items.Item(0)

    End Sub

    Private Sub FilterComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _
            FilterComboBox.SelectedIndexChanged

        FilterItems()

    End Sub

    Private Sub DisplayListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DisplayListBox.SelectedIndexChanged

        'Declaring variables
        Dim foodName, aisleNumber, sectionName As String

        If DisplayListBox.SelectedIndex > -1 Then

            foodName = DisplayListBox.Items.Item(DisplayListBox.SelectedIndex).ToString

            For i As Integer = 0 To CInt(food.Length / 3) - 1
                If food(i, 0) = foodName Then
                    aisleNumber = food(i, 1).ToLower
                    sectionName = food(i, 2)
                    Exit For
                End If
            Next

            If Strings.Right(foodName, 1) = "s" Then
                DisplayLabel.Text = $"The {foodName} are on Aisle {aisleNumber} in the {sectionName} section."
            Else
                DisplayLabel.Text = $"The {foodName} is on Aisle {aisleNumber} in the {sectionName} section."
            End If

        End If

    End Sub

    Private Sub Exit_Procedure(sender As Object, e As EventArgs) Handles ExitMenuToolStripItem.Click,
            ExitContextToolStripItem.Click
        Me.Close()
    End Sub

    Private Sub AboutMenuToolStripItem_Click(sender As Object, e As EventArgs) Handles AboutMenuToolStripItem.Click
        AboutForm.Show()
    End Sub


    ' =========================================  Subs Called By Form Objects  ============================================

    Sub LoadGroceryItems()

        'Declaring variables
        Const fileNumber As Integer = 1     'This needs to be at least one or an error is thrown
        Dim currentLine = "", recordsString = ""
        Dim midLength = 0, count = 0
        Dim itemName, aisleNumber, category, temp() As String
        Dim organizingTable As New Data.DataTable
        Dim dataStyle As DataView

        organizingTable.Columns.Add("Name", GetType(String))
        organizingTable.Columns.Add("Aisle", GetType(String))
        organizingTable.Columns.Add("Category", GetType(String))

        Try

            FileOpen(fileNumber, "../../../Grocery.txt", OpenMode.Input)

            Do Until EOF(fileNumber)
                Input(fileNumber, currentLine)
                recordsString += currentLine
            Loop

            FileClose(fileNumber)
            temp = Split(recordsString, "$$ITM")

            'Load the list and removing bad data
            For i As Integer = 0 To temp.Length - 1

                midLength = InStr(temp(i), "%%CAT", CompareMethod.Text) - (InStr(temp(i), "##LOC", CompareMethod.Text) + 5)

                If midLength > 0 Then
                    itemName = CStr(Split(temp(i), "##LOC")(0))
                    aisleNumber = Mid(temp(i), InStr(temp(i), "##LOC", CompareMethod.Text) + 5, midLength)
                    category = Split(temp(i), "%%CAT")(1)
                Else
                    Continue For
                End If

                If itemName.Length > 0 And aisleNumber.Length > 0 And category.Length > 0 Then
                    organizingTable.Rows.Add(itemName, aisleNumber, category)
                End If

            Next

            dataStyle = organizingTable.DefaultView
            dataStyle.Sort = "Name ASC"
            ReDim food(organizingTable.Rows.Count - 1, 2)     'setting the foodItems array size to hold all grocery values

            organizingTable = dataStyle.ToTable()

            'Moving the data from the data table to the food array
            Array.ForEach(Enumerable.Range(0, 3).ToArray,
                          Sub(x) Array.ForEach(Enumerable.Range(0, organizingTable.Rows.Count).ToArray,
                          Sub(y) food(y, x) = CStr(organizingTable.Rows(y).Item(x))))

        Catch fileNotFound As IO.FileNotFoundException
            MsgBox(fileNotFound.Message)

        Catch badFileName As IO.IOException
            MsgBox(badFileName.Message)

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Sub FilterItems()

        'Declaring variables
        Dim foodList As New List(Of String)
        Dim filterType As Integer
        Dim filterSelection As String

        'Populating food as list
        For i As Integer = 0 To CInt(food.Length / 3) - 1
            foodList.Add(food(i, 0))
        Next

        filterSelection = FilterComboBox.SelectedItem.ToString
        DisplayListBox.Items.Clear()

        If FilterComboBox.SelectedItem.ToString = "Show All" Then

            If SearchTextBox.Text.Trim <> "" Then
                For i As Integer = 0 To foodList.Count - 1
                    If (InStr(food(i, 0), SearchTextBox.Text, CompareMethod.Text) > 0) Then
                        DisplayListBox.Items.Add(foodList.Item(i))
                    End If
                Next
            Else
                'Add all items to display list box
                For i As Integer = 0 To foodList.Count - 1
                    DisplayListBox.Items.Add(foodList.Item(i))
                Next
            End If

        Else
            'Set how the data will be filtered - by aisle or by category
            Select Case True
                Case FilterByAisleRadioButton.Checked
                    filterType = 1
                    filterSelection = LTrim(Strings.Right(filterSelection, 2))
                Case FilterByCategoryRadioButton.Checked
                    filterType = 2
            End Select

            If SearchTextBox.Text.Trim <> "" Then

                For i As Integer = 0 To foodList.Count - 1
                    If (foodList.Item(i).ToString = food(i, 0)) And (food(i, filterType) = filterSelection) And
                        (InStr(food(i, 0), SearchTextBox.Text, CompareMethod.Text) > 0) Then
                        DisplayListBox.Items.Add(foodList.Item(i))
                    End If
                Next

            Else

                'Only place filtered values back in the display list box
                For i As Integer = 0 To foodList.Count - 1
                    If (foodList.Item(i).ToString = food(i, 0)) And food(i, filterType) = filterSelection Then
                        DisplayListBox.Items.Add(foodList.Item(i))
                    End If
                Next

            End If


        End If
    End Sub

    Private Sub StansGroceryForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        SplashScreenForm.Close()
    End Sub

End Class
