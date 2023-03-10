﻿using Moq;
using OnCallDeveloperAPI.Controllers;

namespace OnCallDeveloperAPI.UnitTests;

public class StandardBusinessClockTests
{
    [Fact]
    public void ReturnsTrueDuringBusinessHours()
    {
        var stubbedClock = new Mock<ISystemTime>();
        stubbedClock.Setup(clock => clock.GetCurrent()).Returns(
            new DateTime(1969, 4, 20, 09, 00, 00));
        IProvideTheBusinessClock clock = new StandardBusinessClock(stubbedClock.Object);

        Assert.True(clock.IsDuringBusinessHours());
    }

    [Fact]
    public void ReturnsFalseBeforeBusinessHours()
    {
        var stubbedClock = new Mock<ISystemTime>();
        stubbedClock.Setup(clock => clock.GetCurrent()).Returns(
            new DateTime(1969, 4, 20, 08, 59, 59));
        IProvideTheBusinessClock clock = new StandardBusinessClock(stubbedClock.Object);

        Assert.False(clock.IsDuringBusinessHours());
    }
    [Fact]
    public void ReturnsFalseAfterBusinessHours()
    {
        var stubbedClock = new Mock<ISystemTime>();
        stubbedClock.Setup(clock => clock.GetCurrent()).Returns(
            new DateTime(1969, 4, 20, 16, 00, 00));
        IProvideTheBusinessClock clock = new StandardBusinessClock(stubbedClock.Object);

        Assert.False(clock.IsDuringBusinessHours());
    }
}
