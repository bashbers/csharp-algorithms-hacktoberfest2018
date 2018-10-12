﻿Imports CodeCracker.VisualBasic.Design
Imports Xunit

Namespace Design
    Public Class CatchEmptyTests
        Inherits CodeFixVerifier(Of CatchEmptyAnalyzer, CatchEmptyCodeFixProvider)

        <Fact>
        Public Async Function CatchEmptyAnalyserCreateDiagnostic() As Task
            Const source = "
Imports System
Namespace ConsoleApplication1
    Class TypeName
        Public Async Function Foo() As Task
            Try
                ' Do something
            Catch ex as Exception
                Dim x = 0
            End Try
        End Function
    End Class
End Namespace"
            Await VerifyBasicHasNoDiagnosticsAsync(source)
        End Function

        <Fact>
        Public Async Function WhenFindCatchEmptyThenPutExceptionClass() As Task
            Const source = "
Imports System
Namespace ConsoleApplication1
    Class TypeName
        Public Sub Foo()
            Try
                ' Do something
            Catch
                Dim x = 0
            End Try
        End Sub
    End Class
End Namespace"

            Const fix = "
Imports System
Namespace ConsoleApplication1
    Class TypeName
        Public Sub Foo()
            Try
                ' Do something
            Catch ex As Exception
                Dim x = 0
            End Try
        End Sub
    End Class
End Namespace"
            Await VerifyBasicFixAsync(source, fix, 0)
        End Function

    End Class
End Namespace