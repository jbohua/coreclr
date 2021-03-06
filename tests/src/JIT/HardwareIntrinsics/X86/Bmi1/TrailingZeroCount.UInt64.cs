// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

/******************************************************************************
 * This file is auto-generated from a template file by the GenerateTests.csx  *
 * script in tests\src\JIT\HardwareIntrinsics\X86\Shared. In order to make    *
 * changes, please update the corresponding template and run according to the *
 * directions listed in the file.                                             *
 ******************************************************************************/

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace JIT.HardwareIntrinsics.X86
{
    public static partial class Program
    {
        private static void TrailingZeroCountUInt64()
        {
            var test = new ScalarUnaryOpTest__TrailingZeroCountUInt64();

            if (test.IsSupported)
            {
                // Validates basic functionality works, using Unsafe.ReadUnaligned
                test.RunBasicScenario_UnsafeRead();

                // Validates calling via reflection works, using Unsafe.ReadUnaligned
                test.RunReflectionScenario_UnsafeRead();

                // Validates passing a static member works
                test.RunClsVarScenario();

                // Validates passing a local works, using Unsafe.ReadUnaligned
                test.RunLclVarScenario_UnsafeRead();

                // Validates passing the field of a local class works
                test.RunClassLclFldScenario();

                // Validates passing an instance member of a class works
                test.RunClassFldScenario();

                // Validates passing the field of a local struct works
                test.RunStructLclFldScenario();

                // Validates passing an instance member of a struct works
                test.RunStructFldScenario();
            }
            else
            {
                // Validates we throw on unsupported hardware
                test.RunUnsupportedScenario();
            }

            if (!test.Succeeded)
            {
                throw new Exception("One or more scenarios did not complete as expected.");
            }
        }
    }

    public sealed unsafe class ScalarUnaryOpTest__TrailingZeroCountUInt64
    {
        private struct TestStruct
        {
            public UInt64 _fld;

            public static TestStruct Create()
            {
                var testStruct = new TestStruct();
                var random = new Random();

                testStruct._fld = (ulong)(random.Next(0, int.MaxValue));
                return testStruct;
            }

            public void RunStructFldScenario(ScalarUnaryOpTest__TrailingZeroCountUInt64 testClass)
            {
                var result = Bmi1.TrailingZeroCount(_fld);
                testClass.ValidateResult(_fld, result);
            }
        }

        private static UInt64 _data;

        private static UInt64 _clsVar;

        private UInt64 _fld;

        static ScalarUnaryOpTest__TrailingZeroCountUInt64()
        {
            var random = new Random();
            _clsVar = (ulong)(random.Next(0, int.MaxValue));
        }

        public ScalarUnaryOpTest__TrailingZeroCountUInt64()
        {
            Succeeded = true;

            var random = new Random();
            
            _fld = (ulong)(random.Next(0, int.MaxValue));
            _data = (ulong)(random.Next(0, int.MaxValue));
        }

        public bool IsSupported => Bmi1.IsSupported && (Environment.Is64BitProcess || ((typeof(UInt64) != typeof(long)) && (typeof(UInt64) != typeof(ulong))));

        public bool Succeeded { get; set; }

        public void RunBasicScenario_UnsafeRead()
        {
            var result = Bmi1.TrailingZeroCount(
                Unsafe.ReadUnaligned<UInt64>(ref Unsafe.As<UInt64, byte>(ref _data))
            );

            ValidateResult(_data, result);
        }

        public void RunReflectionScenario_UnsafeRead()
        {
            var result = typeof(Bmi1).GetMethod(nameof(Bmi1.TrailingZeroCount), new Type[] { typeof(UInt64) })
                                     .Invoke(null, new object[] {
                                        Unsafe.ReadUnaligned<UInt64>(ref Unsafe.As<UInt64, byte>(ref _data))
                                     });

            ValidateResult(_data, (UInt64)result);
        }

        public void RunClsVarScenario()
        {
            var result = Bmi1.TrailingZeroCount(
                _clsVar
            );

            ValidateResult(_clsVar, result);
        }

        public void RunLclVarScenario_UnsafeRead()
        {
            var data = Unsafe.ReadUnaligned<UInt64>(ref Unsafe.As<UInt64, byte>(ref _data));
            var result = Bmi1.TrailingZeroCount(data);

            ValidateResult(data, result);
        }

        public void RunClassLclFldScenario()
        {
            var test = new ScalarUnaryOpTest__TrailingZeroCountUInt64();
            var result = Bmi1.TrailingZeroCount(test._fld);

            ValidateResult(test._fld, result);
        }

        public void RunClassFldScenario()
        {
            var result = Bmi1.TrailingZeroCount(_fld);
            ValidateResult(_fld, result);
        }

        public void RunStructLclFldScenario()
        {
            var test = TestStruct.Create();
            var result = Bmi1.TrailingZeroCount(test._fld);

            ValidateResult(test._fld, result);
        }

        public void RunStructFldScenario()
        {
            var test = TestStruct.Create();
            test.RunStructFldScenario(this);
        }

        public void RunUnsupportedScenario()
        {
            Succeeded = false;

            try
            {
                RunBasicScenario_UnsafeRead();
            }
            catch (PlatformNotSupportedException)
            {
                Succeeded = true;
            }
        }

        private void ValidateResult(UInt64 data, UInt64 result, [CallerMemberName] string method = "")
        {
            var isUnexpectedResult = false;

            ulong expectedResult = 0; for (int index = 0; ((data >> index) & 1) == 0; index++) { expectedResult++; } isUnexpectedResult = (expectedResult != result);

            if (isUnexpectedResult)
            {
                TestLibrary.TestFramework.LogInformation($"{nameof(Bmi1)}.{nameof(Bmi1.TrailingZeroCount)}<UInt64>(UInt64): TrailingZeroCount failed:");
                TestLibrary.TestFramework.LogInformation($"    data: {data}");
                TestLibrary.TestFramework.LogInformation($"  result: {result}");
                TestLibrary.TestFramework.LogInformation(string.Empty);
            }
        }
    }
}
