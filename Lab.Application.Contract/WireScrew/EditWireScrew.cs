﻿namespace Ex.Application.Contracts.WireScrew;

public class EditWireScrew : CreateWireScrew
{
    public Guid Guid { get; set; }
    public bool IsAuto { get; set; }
}