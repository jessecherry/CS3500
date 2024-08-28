// <copyright file="FormulaSyntaxTests.cs" company="UofU-CS3500">
//   Copyright (c) 2024 UofU-CS3500. All rights reserved.
// </copyright>
// <authors> Jesse Cherry </authors>
// <date> Aug 21, 2024 </date>

namespace CS3500.FormulaTests;

using CS3500.Formula2; // Change this using statement to use different formula implementations.

/// <summary>
///   <para>
///     The following class shows the basics of how to use the MSTest framework,
///     including:
///   </para>
///   <list type="number">
///     <item> How to catch exceptions. </item>
///     <item> How a test of valid code should look. </item>
///   </list>
/// </summary>
[TestClass]
public class FormulaSyntaxTests
{
    // --- Tests for One Token Rule ---

    /// <summary>
    ///   <para>
    ///     This test makes sure the right kind of exception is thrown when
    ///     trying to create a formula with no tokens.
    ///   </para>
    ///   <remarks>
    ///     <list type="bullet">
    ///       <item>
    ///         We use the _ (discard) notation because the formula object is not used
    ///         after that point in the method.  Note: you can also use _ when a method
    ///         must match an interface but does not use some of the required arguments to
    ///         that method.
    ///       </item>
    ///       <item>
    ///         string.Empty is often considered best practice (rather than using "")
    ///         because it is explicit in intent (e.g., perhaps the coder forgot to put
    ///         something in "").
    ///       </item>
    ///       <item>
    ///         The name of a test method should follow the MS standard:
    ///         https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices
    ///       </item>
    ///       <item>
    ///         All methods should be documented, but perhaps not to the same extent
    ///         as this one.  The remarks here are for your educational
    ///         purposes (i.e., a developer would assume another developer would know these
    ///         items) and would be superfluous in your code.
    ///       </item>
    ///       <item>
    ///         Notice the use of the attribute tag [ExpectedException] which tells the test
    ///         that the code should throw an exception, and if it doesn't an error has occurred;
    ///         i.e., the correct implementation of the constructor should result
    ///         in this exception being thrown based on the given poorly formed formula.
    ///       </item>
    ///     </list>
    ///   </remarks>
    ///   <example>
    ///     <code>
    ///        // here is how we call the formula constructor with a string representing the formula
    ///        _ = new Formula( "5+5" );
    ///     </code>
    ///   </example>
    /// </summary>
    [TestMethod]
    [ExpectedException( typeof( FormulaFormatException ) )]
    public void FormulaConstructor_TestNoTokens_Invalid( )
    {
        _ = new Formula( "" );  /* note: it is arguable that you should replace "" with
                                   string.Empty for readability and clarity of intent (e.g.,
                                   not a cut and paste error or an "I forgot to put something there" error). */
    }

    /// <summary>
    ///   <para>
    ///     Make sure a single token of a number is accepted by the constructor (the
    ///     constructor should not throw an exception).
    ///   </para>
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestNumber_Valid()
    {
        _ = new Formula("1889");
    }

    /// <summary>
    ///   <para>
    ///     Make sure a single token using scientific notation with a lowercase "e" is
    ///     accepted by the constructor (the constructor should not throw an exception).
    ///   </para>
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestSciNotLowEToken_Valid()
    {
        _ = new Formula("2e5");
    }

    /// <summary>
    ///   <para>
    ///     Make sure a single token using scientific notation with a capital "E" is
    ///     accepted by the constructor (the constructor should not throw an exception).
    ///   </para>
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestSciNotCapEToken_Valid()
    {
        _ = new Formula("2E5");
    }

    /// <summary>
    ///   <para>
    ///     Make sure a single token using scientific notation with a negative exponent is
    ///     accepted by the constructor (the constructor should not throw an exception).
    ///   </para>
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestSciNotNegExpToken_Valid()
    {
        _ = new Formula("8E-7");
    }

    /// <summary>
    ///   <para>
    ///     Make sure a single token using a properly formatted variable is accepted by
    ///     the constructor (the constructor should not throw an exception).
    ///   </para>
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestVariableToken_Valid()
    {
        _ = new Formula("a67");
    }

    /// <summary>
    ///   <para>
    ///     Make sure an invalid variable token (number before letter) is NOT accepted by
    ///     the constructor (the constructor should throw an exception).
    ///   </para>
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestVariableNumberFirst_Invalid()
    {
        _ = new Formula("7ab");
    }

    /// <summary>
    ///   <para>
    ///     Make sure an invalid variable token (letter, number, letter) is NOT accepted by
    ///     the constructor (the constructor should throw an exception).
    ///   </para>
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestVariableLetterNumLetter_Invalid()
    {
        _ = new Formula("x9v");
    }

    /// <summary>
    ///   <para>
    ///     Make sure an invalid variable token (letter only) is NOT accepted by the
    ///     constructor (the constructor should throw an exception).
    ///   </para>
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestVariableLetterOnly_Invalid()
    {
        _ = new Formula("m");
    }

    /// <summary>
    ///   <para>
    ///     Make sure a single invalid token is NOT accepted by the constructor (the
    ///     constructor should throw an exception).
    ///   </para>
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestInvalidToken_Invalid()
    {
        _ = new Formula("$");
    }

    // --- Tests for All Valid Tokens Rule ---

    /// <summary>
    ///   <para>
    ///     Make sure an invalid token among valid tokens is NOT accepted by the constructor
    ///     (the constructor should throw an exception).
    ///   </para>
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestInvalidAndValidTokens_Invalid()
    {
        _ = new Formula("8 $ n44");
    }

    // --- Tests for Closing Parenthesis Rule

    // --- Tests for Balanced Parentheses Rule

    // --- Tests for First Token Rule

    /// <summary>
    ///   <para>
    ///     Make sure a simple well-formed formula is accepted by the constructor (the constructor
    ///     should not throw an exception).
    ///   </para>
    ///   <remarks>
    ///     This is an example of a test that is not expected to throw an exception, i.e., it succeeds.
    ///     In other words, the formula "1+1" is a valid formula which should not cause any errors.
    ///   </remarks>
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestFirstTokenNumber_Valid( )
    {
        _ = new Formula( "1+1" );
    }

    /// <summary>
    ///  <para>
    ///     Make sure a simple well-formed formula surrounded by a pair of parentheses is accepted
    ///     by the constructor (the constructor should not throw an exception).
    ///   </para>
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestFirstTokenParenthesis_Valid()
    {
        _ = new Formula( "(1 + 1)" );
    }

    // --- Tests for  Last Token Rule ---

    // --- Tests for Parentheses/Operator Following Rule ---

    // --- Tests for Extra Following Rule ---
}
