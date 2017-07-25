namespace LAD08PackagingV1
{
    public enum PackingStates
    {
        Unknown,
        WakingUp,
        NoWorkOrder,
        ReadBarcodeProdOrderNumber,
        ReadBarcodeReferemce,
        ReadBarcodeTarget,
        LoadingReference,
        WaitingForProduct,
        PrintingLabeL,
        PrintingGroupingLabel,
        SetWeighing,
        WaitingBarcode,
        ProductPassed,
        ProductFailed,
        RejectBin,
        BoxError,
        CreateWorkOrder,
        AskToRemoveLabel,
        PrintingIndividualFail
    }
}