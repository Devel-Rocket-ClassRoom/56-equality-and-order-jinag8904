using System;
using System.Collections.Generic;

List<TodoTask> tasks = new()
{
    new TodoTask("보고서 작성", 3, "2026-03-15"),
    new TodoTask("코드 리뷰", 3, "2026-03-10"),
    new TodoTask("이메일 확인", 1, "2026-03-10"),
    new TodoTask("회의 준비", 2, "2026-03-12"),
    new TodoTask("버그 수정", 3, "2026-03-10")
};

Console.WriteLine("=== 정렬 전 ===");
foreach (TodoTask task in tasks) Console.WriteLine(task);

Console.WriteLine("\n=== 정렬 후 ===");
tasks.Sort();
foreach (TodoTask task in tasks) Console.WriteLine(task);