using System;

class TodoTask : IComparable<TodoTask>
{
    string Title;
    int Priority;
    string DueDate;

    public TodoTask(string title, int priority, string duedate)
    {
        Title = title;
        Priority = priority;
        DueDate = duedate;
    }

    public int CompareTo(TodoTask other)
    {
        int result = -Priority.CompareTo(other.Priority);
        if (result != 0) return result;

        result = DueDate.CompareTo(other.DueDate);
        if (result != 0) return result;

        return Title.CompareTo(other.Title);
    }

    public override string ToString() => $"[우선순위 {Priority}] {Title} (마감: {DueDate})";
}