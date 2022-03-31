using System;

namespace Week1
{
    class Program
    {
        static void Main()
        {
            // COMPUTATIONAL MATHS //
            /////////////////////////
            // Sets:
            //A set represents a collection of similar objects (elements).
            int[] mainSetExtras = new int[2] {8, 10};
            int[] setA = new int[6] { 1, 2, 3, 4, 7, 9 };
            int[] setB = new int[4] { 2, 3, 5, 6 };
            int[] mainSet = CMCreateMain(setA, setB, mainSetExtras);

            // Set operations:
            //Union, the set of elements of A and B combined.
            int[] setUnion = CMUnion(setA, setB);
            //Intersection,the set of common elements of A and B.
            int[] setIntersection = CMIntersection(setA, setB);
            //Difference, the set of elements in A but not in B.
            int[] setDifferenceA = CMDifference(setA, setB);
            int[] setDifferenceB = CMDifference(setB, setA);
            // Symmetric difference: the set of elements in each A and B, but not in common.
            int[] setSymmetricDifference = CMSymmetricDifference(setA, setB);
            // Complement: the set of elements in mainSet but outside subset A.
            int[] setComplementA = CMComplement(mainSet, setA);
            int[] setComplementB = CMComplement(mainSet, setB);
        }

        static int[] CMCreateMain(int[] setA, int[] setB, int[] mainSetExtras)
        {
            int[] setUnion1 = CMUnion(setA, setB);
            int[] setUnion2 = CMUnion(setUnion1, mainSetExtras);
            Array.Sort(setUnion2);
            return setUnion2;
        }

        static int[] CMUnion(int[] setA, int[] setB)
        {
            // Create needed vairables for the function
            int[] buffer = new int[setA.Length + setB.Length];
            int bufferLocation = 0;
            int Alooper = 0;            int Blooper = 0;
            bool MatchingFlag = false;

            // Put all of setA into the buffer as we will be adding the new elements from setB to it later
            while (Alooper != setA.Length)
            {
                buffer[bufferLocation] = setA[Alooper];
                Alooper++;
                bufferLocation++;
            }
            Alooper = 0; //<--- resetting the looper for reuse

            // Find all the new elements from setB and add them to the buffer
            while (Blooper != setB.Length)
            {
                while (Alooper != setA.Length && MatchingFlag != true)
                {
                    if (setB[Blooper] == setA[Alooper])
                    {
                        MatchingFlag = true;
                    }
                    Alooper++;
                }
                Alooper = 0;

                if (MatchingFlag == false)
                {
                    buffer[bufferLocation] = setB[Blooper];
                    bufferLocation++;
                }
                Blooper++;
                MatchingFlag = false;
            }

            // Resize final set ready to return
            Array.Resize(ref buffer, bufferLocation);
            Array.Sort(buffer);
            return buffer;
        }

        static int[] CMIntersection(int[] setA, int[] setB)
        {
            // Create needed vairables for the function
            int[] buffer = new int[setA.Length + setB.Length];
            int bufferLocation = 0;
            int Alooper = 0;            int Blooper = 0;
            bool MatchingFlag = false;

            // Find all matching elements
            while (Alooper != setA.Length)
            {
                while (Blooper != setB.Length && MatchingFlag != true)
                {
                    if (setA[Alooper] == setB[Blooper])
                    {
                        buffer[bufferLocation] = setA[Alooper];
                        bufferLocation++;
                        MatchingFlag = true;
                    }
                    Blooper++;
                }
                MatchingFlag = false;
                Blooper = 0;
                Alooper++;
            }

            // Resize final set ready to return
            Array.Resize(ref buffer, bufferLocation);
            Array.Sort(buffer);
            return buffer;

        }

        static int[] CMDifference(int[] setA, int[] setB)
        {
            // Create needed vairables for the function
            int[] buffer = new int[setA.Length + setB.Length];
            int bufferLocation = 0;
            int Alooper = 0;            int Blooper = 0;
            bool MatchingFlag = false;

            // Find all matching elements
            while (Alooper != setA.Length)
            {
                while (Blooper != setB.Length && MatchingFlag != true)
                {
                    if (setA[Alooper] == setB[Blooper])
                    {
                        MatchingFlag = true;
                    }
                    Blooper++;
                }
                if (MatchingFlag != true)
                {
                    buffer[bufferLocation] = setA[Alooper];
                    bufferLocation++;
                }
                MatchingFlag = false;
                Blooper = 0;
                Alooper++;
            }

            // Resize final set ready to return
            Array.Resize(ref buffer, bufferLocation);
            Array.Sort(buffer);
            return buffer;
        }

        static int[] CMSymmetricDifference(int[] setA, int[] setB)
        {
            int[] setDifferenceA = CMDifference(setA, setB);
            int[] setDifferenceB = CMDifference(setB, setA);
            int[] buffer = new int[setA.Length + setB.Length];
            int bufferLocation = 0;
            int Alooper = 0;            int Blooper = 0;
            
            while (Alooper != setDifferenceA.Length)
            {
                buffer[bufferLocation] = setDifferenceA[Alooper];
                Alooper++;
                bufferLocation++;
            }
            while (Blooper != setDifferenceB.Length)
            {
                buffer[bufferLocation] = setDifferenceB[Blooper];
                Blooper++;
                bufferLocation++;
            }

            // Resize final set ready to return
            Array.Resize(ref buffer, bufferLocation);
            Array.Sort(buffer);
            return buffer;

        }

        static int[] CMComplement(int[] mainSet, int[] removeSet)
        {
            // Create needed vairables for the function
            int[] buffer = new int[mainSet.Length];
            int bufferLocation = 0;
            int Mainlooper = 0;            int Removelooper = 0;
            bool MatchingFlag = false;

            // Find all matching elements
            while (Mainlooper != mainSet.Length)
            {
                while (Removelooper != removeSet.Length && MatchingFlag != true)
                {
                    if (mainSet[Mainlooper] == removeSet[Removelooper])
                    {
                        MatchingFlag = true;
                    }
                    Removelooper++;
                }
                if (MatchingFlag != true)
                {
                    buffer[bufferLocation] = mainSet[Mainlooper];
                    bufferLocation++;
                }
                MatchingFlag = false;
                Removelooper = 0;
                Mainlooper++;
            }

            // Resize final set ready to return
            Array.Resize(ref buffer, bufferLocation);
            Array.Sort(buffer);
            return buffer;
        }


    }
}
