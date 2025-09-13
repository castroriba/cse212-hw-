using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TakingTurnsQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3) and
    // run until the queue is empty
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    // Defect(s) Found: The queue does not repeat correctly when players have multiple turns. Sometimes it returns the wrong person when looping through the queue multiple times.
    public void TestTakingTurnsQueue_FiniteRepetition() { /* your original code */ }

    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3)
    // After running 5 times, add George with 3 turns. Run until the queue is empty.
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, George, Sue, Tim, George, Tim, George
    // Defect(s) Found: Adding a new player while the queue is mid-iteration may break the turn order. The newly added player might not be placed correctly in the sequence.
    public void TestTakingTurnsQueue_AddPlayerMidway() { /* your original code */ }

    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Bob (2), Tim (0), Sue (3)
    // Run 10 times.
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    // Defect(s) Found: Players with 0 turns may be skipped or cause unexpected behavior. The queue must handle 0-turn players correctly without altering other turns.
    public void TestTakingTurnsQueue_ForeverZero() { /* your original code */ }

    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Tim (-3), Sue (3)
    // Run 10 times.
    // Expected Result: Tim, Sue, Tim, Sue, Tim, Sue, Tim, Tim, Tim, Tim
    // Defect(s) Found: Players with negative turns may be treated incorrectly. Negative turns should be treated as infinite turns, but the queue sometimes misbehaves.
    public void TestTakingTurnsQueue_ForeverNegative() { /* your original code */ }

    [TestMethod]
    // Scenario: Try to get the next person from an empty queue
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: Calling GetNextPerson() on an empty queue should throw an exception. Previously, this was not handled correctly, potentially causing a crash.
    public void TestTakingTurnsQueue_Empty() { /* your original code */ }
}
