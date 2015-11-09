namespace PetStore.Importer.Importers

{
    using System;
    using System.IO;
    using Data;

    public interface IImporter
    {
        string Message { get; }

        int Order { get; }

        Action<PetStoreEntities, TextWriter> Get { get; }
    }
}
