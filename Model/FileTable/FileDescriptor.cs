using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ToyLanguage.Model.FileTable
{
    class FileDescriptor
    {
        public string fileName;
        StreamReader reader;

        public FileDescriptor(string fileName, StreamReader reader)
        {
            this.fileName = fileName;
            this.reader = reader;
        }

        public string FileName
        {
            get { return fileName; }
        }

        public StreamReader Reader
        {
            get { return reader; }
        }

        public override bool Equals(object obj)
        {
            if (obj is FileDescriptor)
            {
                FileDescriptor fd = obj as FileDescriptor;
                return fd.FileName == FileName;
            }
            return false;
        }

        public static bool operator ==(FileDescriptor lfd, FileDescriptor rfd)
        {
            return lfd.FileName == rfd.FileName;
        }

        public static bool operator !=(FileDescriptor lfd, FileDescriptor rfd)
        {
            return lfd.FileName != rfd.FileName;
        }

        public override int GetHashCode()
        {
            return FileName.GetHashCode();
        }

        public override string ToString()
        {
            return fileName;
        }
    }
}
