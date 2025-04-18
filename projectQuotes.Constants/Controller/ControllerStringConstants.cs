﻿namespace projectQuotes.Constants.Controller;

public static class ControllerStringConstants
{
    public const string JsonImageReturnType = "image/webp";


    //Policies

    public const string CanAccessEveryone = "CanAccessEveryone";

    public const string CanAccessUserAndAdmin = "CanAccessUserAndAdmin";

    public const string CanAccessOnlyAdmin = "CanAccessOnlyAdmin";

    //Error messages
    public const string ErrorMessageThisEndpointCanAccess = "This endpoint can access only users with the next rolls: ";

    public const string EmailIsntFormatedCorrectlyErrorMessage = "Email isn't formated correctly";

    public const string IdIsRequiredErrorMessage = "Id is required";

    public const string SomethingWentWrongDuringCreateing = "Something went wrong during createing ";

    public const string ModelUpdatedSuccessfully = "Model was udpated successfully";

    public const string SomethingWentWrongDuringUpdateing = "Something went wrong during updateing";


    public const string ModelWithThisIdDoesntExistForUpdateEndPoint =
        "Model with this id doesn't exit this endpoint only for update models it can't handler ids that don't exist";


    public const string ThisFileFormatIsntAllowedYouCanUseTheFollowing =
        "This file format isn't allowed you can use the following: ";

    public const string FileMustNotBeNullErrorMessage = "File must not be null";

    public const string MaximumSizeCanBe = "Maximum size can be ";

    public const string ThisFieldCantBeNull = "This field can't be null";


    //other things

    public const string EndpointForDisplayImage = "displayImage";

    public const string Version = "api/v1";
}
