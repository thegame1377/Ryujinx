﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ARMeilleure.Decoders
{
    class OpCode32SimdMovGpDouble : OpCode32, IOpCode32Simd
    {
        public int Size => 3;

        public int Vm { get; private set; }
        public int Rt { get; private set; }
        public int Rt2 { get; private set; }
        public int Op { get; private set; }
        public OpCode32SimdMovGpDouble(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
            // which one is used is instruction dependant
            Op = ((opCode >> 20) & 0x1);
            
            Rt = (opCode >> 12) & 0xf;
            Rt2 = (opCode >> 16) & 0xf;

            bool single = (opCode & (1 << 8)) == 0;
            if (single)
            {
                Vm = ((opCode >> 5) & 0x1) | ((opCode << 1) & 0x1e);
            } 
            else
            {
                Vm = ((opCode >> 1) & 0x10) | ((opCode >> 0) & 0xf);
            }
        }
    }
}
