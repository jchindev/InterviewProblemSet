using System;
using FluentAssertions;
using Xbehave;

namespace InterviewProblemSet
{
    public class ArrayFunctionsFeature
    {
        [Scenario]
        //note: Example attribute is a scenario outline where the
        //first arg is array1, second arg is array2, third arg is expected result
        [Example(new[] {0, 2, 3}, new[] {1, 3, 4, 5}, new[] {0, 1, 2, 3, 3, 4, 5})]
        [Example(new [] { 3, 5, 6, 9, 12, 14, 18, 20, 25, 28 }, new [] { 30, 32, 34, 36, 38, 40, 42, 44, 46, 48 },
            new [] { 3, 5, 6, 9, 12, 14, 18, 20, 25, 28, 30, 32, 34, 36, 38, 40, 42, 44, 46, 48 })]
        public void MergeSortedArrays(int[] array1, int[] array2, 
            int[] expectedResult, ArrayFunctions arrayFunctions, int[] result)
        {
            $"Given an {nameof(array1)} with values: [{string.Join(",", array1)}]"
                .x(() => { });

            $"And an {nameof(array2)} with values: [{string.Join(",", array2)}]"
                .x(() => { });

            $"And a {nameof(ArrayFunctions)} object"
                .x(() => arrayFunctions = new ArrayFunctions());

            "When I combine the arrays"
                .x(() => result = arrayFunctions.MergeSortedArrays(array1, array2));

            $"The {nameof(result)} should equal the {nameof(expectedResult)}: [{string.Join(",", expectedResult)}]}}"
                .x(() => result.ShouldAllBeEquivalentTo(expectedResult));
        }

        [Scenario]
        //note: Example attribute is a scenario outline where the
        //first arg is array, second arg is expected result
        [Example(new[] { 10, 3, 0, -2, 12, 5, 1, 1, 4 }, 600)]
        [Example(new[] { 10, 3, 5}, 150)]
        public void GetMaxProd3Elements(int[] array, int expectedResult, ArrayFunctions arrayFunctions, int result)
        {
            $"Given an {nameof(array)} with values: [{string.Join(",", array)}]"
                .x(() => { });

            $"And a {nameof(ArrayFunctions)} object"
                .x(() => arrayFunctions = new ArrayFunctions());

            $"When I call {nameof(arrayFunctions.GetMaxProductOf3Elements)}"
                .x(() => result = arrayFunctions.GetMaxProductOf3Elements(array));

            $"The {nameof(result)} should equal to the {nameof(expectedResult)}: {expectedResult}"
                .x(() => result.ShouldBeEquivalentTo(expectedResult));
        }

        [Scenario]
        //note: Example attribute is a scenario outline where the
        //first arg is array, second arg is expected result
        [Example(new[] { 10, 3, 0, -2, 12, 5, 1, 1, Int32.MaxValue }, "product is an invalid integer value")]
        [Example(new[] { 10, 3 }, "Need at least 3 array elements")]
        public void GetMaxProd3Errors(int[] array, string expectedResult, ArrayFunctions arrayFunctions, Action actionResult)
        {
            $"Given an {nameof(array)} with values: [{string.Join(",", array)}]"
                .x(() => { });

            $"And a {nameof(ArrayFunctions)} object"
                .x(() => arrayFunctions = new ArrayFunctions());

            $"When I call {nameof(arrayFunctions.GetMaxProductOf3Elements)}"
                .x(() => actionResult = () => arrayFunctions.GetMaxProductOf3Elements(array));

            $"The result should equal the {nameof(expectedResult)}: {expectedResult}"
                .x(() => actionResult.ShouldThrow<ArgumentException>().WithMessage(expectedResult));
        }

    }
}