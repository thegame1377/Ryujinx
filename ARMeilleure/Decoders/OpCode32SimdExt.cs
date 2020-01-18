﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ARMeilleure.Decoders
{
    class OpCode32SimdExt : OpCode32SimdReg
    {
        public int Immediate { get; private set; }
        public OpCode32SimdExt(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
            Immediate = (opCode >> 8) & 0xf;
            Size = 0;
            if (DecoderHelper.VectorArgumentsInvalid(Q, Vd, Vm, Vn) || (!Q && Immediate > 7))
            {
                Instruction = InstDescriptor.Undefined;
            }
        }
    }
}
