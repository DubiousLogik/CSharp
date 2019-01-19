using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SyntaxRunner.Models;

namespace SyntaxRunner.ObjOr
{
    public class Mutability
    {
        public void RunMutabilityExamples()
        {
            // fun with constants : strings, numbers, null are truly immutable
            const string foo = "bar";
            const double pi = Math.PI;
            const StringBuilder sbConst = null;  // null is immutable

            if (sbConst == null)
            {
                Console.WriteLine("null objects can be const");
                //Console.WriteLine(sbConst.GetHashCode());  // will fail
                //sbConst = new StringBuilder();  // will fail
            }

            var sb = new StringBuilder();
            Console.WriteLine($"sb Id at create: {sb.GetHashCode()}");
            Console.WriteLine($"sb value 1: {sb.ToString()}");

            AlterStringBuilder(sb, "Foo");
            Console.WriteLine($"sb value 2: {sb.ToString()}");

            SetToNull(sb);
            Console.WriteLine($"sb value 3: {sb.ToString()}");

            ImmutabilityRunner();

            var itemUpdateState = new ItemUpdateState();
            Console.WriteLine($"itemUpdateState.HasBeenUpdated = {itemUpdateState.HasBeenUpdated}");

            ItemUpdateState itemUpdateState2 = null;

            var temp = itemUpdateState2?.HasBeenUpdated;
            Console.WriteLine($"temp {temp}");
            if (temp == null)
            {
                Console.WriteLine("temp is null");
            }
        }

        public static void AlterStringBuilder(StringBuilder sb, string input)
        {
            sb.Append(input);
            Console.WriteLine($"sb Id inside method: {sb.GetHashCode()}");
        }

        public static void SetToNull(object o)
        {
            // at this moment o points to the same object as sb above
            Console.WriteLine($"o Id before null: {o.GetHashCode()}");

            o = null; // this sets local var o to null, sb is unchanged
            Console.WriteLine($"o Id after null: {o?.GetHashCode()}");
        }

        public static void ImmutabilityRunner()
        {
            var objTester = new GenericObject();

            Console.WriteLine($"syntax class sb value 1: {objTester.StringBuilderReadOnly.ToString()}");
            var thisSb = objTester.StringBuilderReadOnly;

            thisSb.Append(" | foo");
            Console.WriteLine($"thisSb value (ii): {thisSb.ToString()}");
            Console.WriteLine($"syntax class sb value 2: {objTester.StringBuilderReadOnly.ToString()}");

            Console.WriteLine();
            objTester.Add(" | yet another string");
            Console.WriteLine($"syntax class sb value 3: {objTester.StringBuilderReadOnly.ToString()}");
            Console.WriteLine($"thisSb value (iii): {thisSb.ToString()}");

            Console.WriteLine();
            objTester.StringBuilderReadOnly.Append(" | last string");
            Console.WriteLine($"syntax class sb value 4: {objTester.StringBuilderReadOnly.ToString()}");
            Console.WriteLine($"syntax GetContents: {objTester.GetContents()}");
            Console.WriteLine($"syntax GetContentsImmutable: {objTester.GetContentsImmutable()}");
            Console.WriteLine($"syntax GetContentsMutable: {objTester.GetContentsMutable()}");

            Console.WriteLine();
            var bytes = objTester.GetContentAsBytes();
            bytes[0] = Encoding.ASCII.GetBytes("A")[0];
            Console.WriteLine($"syntax GetContentsImmutable: {objTester.GetContentsImmutable()}");
            Console.WriteLine($"syntax GetContents: {objTester.GetContents()}");
            Console.WriteLine($"syntax GetContentsMutable: {objTester.GetContentsMutable()}");

            Console.WriteLine();
            var otherBytes = objTester.GetCopyOfBytes();
            otherBytes[1] = Encoding.ASCII.GetBytes("X")[0];
            Console.WriteLine($"syntax GetContentsImmutable: {objTester.GetContentsImmutable()}");
            Console.WriteLine($"syntax GetContents: {objTester.GetContents()}");
            Console.WriteLine($"syntax GetContentsMutable: {objTester.GetContentsMutable()}");
            Console.WriteLine($"otherBytes: {Encoding.ASCII.GetString(otherBytes)}");

            Console.WriteLine();
            var otherBytes2 = objTester.GetCopyOfBytesImmutable();
            otherBytes2[1] = Encoding.ASCII.GetBytes("Z")[0];
            Console.WriteLine($"otherBytes2: {Encoding.ASCII.GetString(otherBytes2)}");

            Console.WriteLine();
            Console.WriteLine($"bytes id {bytes.GetHashCode().ToString()}");
            Console.WriteLine($"otherBytes id {otherBytes.GetHashCode().ToString()}");
            Console.WriteLine($"otherBytes2 id {otherBytes2.GetHashCode().ToString()}");
        }
    }
}
