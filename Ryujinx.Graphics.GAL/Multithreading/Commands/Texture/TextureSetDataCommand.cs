﻿using Ryujinx.Graphics.GAL.Multithreading.Model;
using Ryujinx.Graphics.GAL.Multithreading.Resources;
using System;

namespace Ryujinx.Graphics.GAL.Multithreading.Commands.Texture
{
    struct TextureSetDataCommand : IGALCommand
    {
        public CommandType CommandType => CommandType.TextureSetData;
        private TableRef<ThreadedTexture> _texture;
        private TableRef<byte[]> _data;

        public void Set(TableRef<ThreadedTexture> texture, TableRef<byte[]> data)
        {
            _texture = texture;
            _data = data;
        }

        public void Run(ThreadedRenderer threaded, IRenderer renderer)
        {
            ThreadedTexture texture = _texture.Get(threaded);
            texture.Base.SetData(new ReadOnlySpan<byte>(_data.Get(threaded)));
        }
    }
}
