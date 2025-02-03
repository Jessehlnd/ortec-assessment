using NUnit.Framework;
using System;

[TestFixture]
public class TaskListTests
{
    private TaskList taskList;

    [SetUp]
    public void Setup()
    {
        taskList = new TaskList();
    }

    [Test]
    public void SetDeadline_ValidInput_UpdatesDeadline()
    {
        var taskId = 1; 
        var deadline = "25-11-2024";

        taskList.Execute($"deadline {taskId} {deadline}");

        var task = taskList.GetTaskById(taskId);
        Assert.AreEqual(DateTime.Parse(deadline), task.Deadline);
    }

    [Test]
    public void SetDeadline_InvalidTaskId_ShowsErrorMessage()
    {
        var invalidTaskId = -42; 
        var deadline = "2024-25-11";

        Assert.Throws<Exception>(() => taskList.Execute($"deadline {invalidTaskId} {deadline}"));
    }

    [Test]
    public void SetDeadline_InvalidDateFormat_ShowsErrorMessage()
    {
        var taskId = 1; 
        var invalidDate = "25-11-2024";

        Assert.Throws<FormatException>(() => taskList.Execute($"deadline {taskId} {invalidDate}"));
    }

} 