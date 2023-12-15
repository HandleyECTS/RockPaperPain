Imports System.Security.Cryptography.X509Certificates

Module Module1
    'Logan Handley
    '12/12/23
    'Rock Paper Scissors
    Dim user(4) As String
    Dim cmp(4) As String
    Dim result(4) As String
    Dim winP As Double
    Dim lossP As Double
    Dim tieP As Double
    Dim wins, losses, ties As Integer
    Sub Main()
        Dim round As Integer = 0

        PrintTitle()
        For i As Integer = 0 To 4
            user(i) = UserMove()
            cmp(i) = ComputerMove()
            result(i) = DetermineOutcome(user(i), cmp(i))
            Console.Clear()
            Console.WriteLine($"The user chose {user(i)}")
            Console.WriteLine($"And the computer chose {cmp(i)}")
            Console.WriteLine($"The winner is: {result(i)}!" & vbNewLine)
            round += 1
            percents(result(i))
        Next
        PrintPercent()
        PrintReport()
        Console.ReadKey()
    End Sub

    ''' <summary>
    ''' Accepts 4 strings (round, userplay, compplay, outcome) and prints a line out of the report.
    ''' </summary>
    Sub PrintReportLine(round, userplay, compplay, outcome)
        Console.WriteLine("{0} | {1} | {2} | {3}", round.ToString.PadRight(10), userplay.ToString.PadRight(10), compplay.ToString.PadRight(10), outcome.ToString.PadRight(10))

    End Sub

    ''' <summary>
    ''' Prints the headers, loops through, prints the report lines, then prints a summary with calculations and determines a winn4er.
    ''' </summary>
    Sub PrintReport()
        Console.WriteLine("Round # ".PadRight(11) & "| " & "User ".PadRight(11) & "| " & "Computer ".PadRight(11) & "| " & "Outcome")
        Console.WriteLine("-".PadRight(50, "-"))
        For i As Integer = 0 To 4
            PrintReportLine(i + 1, user(i), cmp(i), result(i))
        Next
        Console.WriteLine("-".PadRight(50, "-"))
        Console.WriteLine("Percent of wins: " & winP.ToString("P2"))
        Console.WriteLine("Percent of losses: " & lossP.ToString("P2"))
        Console.WriteLine("Percent of ties: " & tieP.ToString("P2"))
        Console.WriteLine()
        If winP > lossP And winP > tieP Then
            Console.WriteLine("You won the set!")
        ElseIf lossP > winP And lossP > tieP Then
            Console.WriteLine("You lost the set.")
        ElseIf tieP > lossP And tieP > winP Then
            Console.WriteLine("You tied the set!")
        End If
    End Sub

    ''' <summary>
    ''' Finds the percentages of wins/losses/ties
    ''' </summary>
    Sub percents(str As String)
        If str = "User" Then
            wins += 1
        ElseIf str = "Computer" Then
            losses += 1
        ElseIf str = "Neither" Then
            ties += 1
        End If
    End Sub

    Sub PrintPercent()
        winP = wins / 5
        lossP = losses / 5
        tieP = ties / 5
    End Sub

    ''' <summary>
    ''' Prints the ASCII art title screen.
    ''' </summary>
    Sub PrintTitle()
        Console.WriteLine("
.-. .-. .-. . .     .-. .-. .-. .-. .-.     .-. .-. .-. .-. .-. .-. .-. .-.
|(  | | |   |<      |-' |-| |-' |-  |(      `-. |    |  `-. `-. | | |(  `-.
' ' `-' `-' ' ` ,   '   ` ' '   `-' ' ' ,   `-' `-' `-' `-' `-' `-' ' ' `-'
    _______           _______               _______
---'   ____)      ---'   ____)____     ---'    ____)____
      (_____)               ______)               ______)
      (_____)               _______)           __________)
      (____)               _______)           (____)
---.__(___)       ---.__________)      ---.__(___)
")
    End Sub

    ''' <summary>
    ''' Returns rock, paper, or scissors representing the computer's play.
    ''' </summary>
    ''' <returns></returns>
    Function ComputerMove() As String
        Dim rand As New Random
        Dim cmp As Integer = rand.Next(1, 4)
        If cmp = 1 Then
            Return "Rock"
        ElseIf cmp = 2 Then
            Return "Paper"
        ElseIf cmp = 3 Then
            Return "Scissors"
        End If
    End Function

    ''' <summary>
    ''' Repeatedly prompts the user for a 1, 2, or 3, and then returns the input once valid input is given
    ''' </summary>
    ''' <returns></returns>
    Function UserMove()
        Dim input As String
        Dim int As Integer = 0
        Do
            Console.Write("Please enter 1 (Rock), 2 (Paper), or 3 (Scissors) -> ")
            input = Console.ReadLine
            Integer.TryParse(input, int)
            If int < 1 Or int > 3 Then
                Console.WriteLine("Invalid input, please try again")
            End If
        Loop While int < 1 Or int > 3
        If int = 1 Then
            Return "Rock"
        ElseIf int = 2 Then
            Return "Paper"
        ElseIf int = 3 Then
            Return "Scissors"
        End If
    End Function

    ''' <summary>
    ''' Accepts a num and returns “Rock” (1) “Paper” (2) “Scissors” (3), otherwise it returns “invalid” 
    ''' </summary>
    ''' <returns></returns>
    Function ConvertNumToWord(input As String)
        If input = 1 Then
            Return "Rock"
        ElseIf input = 2 Then
            Return "Paper"
        ElseIf input = 3 Then
            Return "Scissors"
        Else
            Return "Invalid."
        End If
    End Function

    ''' <summary>
    ''' Accepts a usermove, a computermove (ints) and then returns “Win”, “Loss”, or “Tie” 
    ''' </summary>
    ''' <returns></returns>
    Function DetermineOutcome(user As String, cmp As String)
        If (user = "Rock" AndAlso cmp = "Paper") Or (user = "Paper" AndAlso cmp = "Scissors") Or (user = "Scissors" AndAlso cmp = "Rock") Then
            Return "Computer"
        ElseIf (cmp = "Rock" AndAlso user = "Paper") Or (cmp = "Paper" AndAlso user = "Scissors") Or (cmp = "Scissors" AndAlso user = "Rock") Then
            Return "User"
        ElseIf user = cmp Then
            Return "Neither"
        Else
            Return "Invalid Input"
        End If
    End Function

End Module
