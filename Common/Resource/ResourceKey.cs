namespace Common.Resource
{
    public static class ResourceKey
    {
        #region ValidationError

        #region Empty
        public static string EmptyFirstName => "EmptyFirstName";
        public static string EmptyLastName => "EmptyLastName";
        public static string EmptyAddressId => "EmptyAddressId";
        public static string EmptyProvinceName => "EmptyProvinceName";
        public static string EmptyStreetName => "EmptyStreetName";
        public static string EmptyCityName => "EmptyCityName";
        public static string EmptyHouseNumber => "EmptyHouseNumber";
        public static string EmptyReceiverName => "EmptyReceiverName";
        public static string EmptyLocationPosition => "EmptyLocationPosition";
        public static string EmptyUsername => "EmptyUsername";
        public static string EmptyCartHeader => "EmptyCartHeader";
        public static string EmptyCategoryId => "EmptyCategoryId";
        public static string EmptyOrderHeader => "EmptyOrderHeader";
        public static string EmptyOrderHeaderId => "EmptyOrderHeaderId";
        public static string EmptyProductId => "EmptyProductId";
        public static string EmptyAuthorityKey => "EmptyAuthorityKey";
        public static string EmptyPaymentStatus => "EmptyPaymentStatus";
        public static string EmptyBuyerId => "EmptyBuyerId";
        public static string EmptyOrderDetail => "EmptyOrderDetail";
        public static string EmptyProfileId => "EmptyProfileId";
        public static string EmptyBirthYear => "EmptyBirthYear";
        public static string EmptyBirthMonth => "EmptyBirthMonth";
        public static string EmptyBirthDay => "EmptyBirthDay";
        public static string EmptyPostalCode => "EmptyPostalCode";
        public static string EmptyCompleteAddress => "EmptyCompleteAddress";
        public static string EmptyMobilePhoneNumber => "EmptyMobilePhoneNumber";
        public static string EmptyAddressTitle => "EmptyAddressTitle";
        public static string EmptyCartId => "EmptyCartId";
        public static string EmptyUserCart => "EmptyUserCart";
        public static string EmptyPaymentUrl => "EmptyPaymentUrl";
        public static string EmptyCartDetail => "EmptyCartDetail";
        public static string EmptyUser => "EmptyUser";
        public static string EmptyPartId => "EmptyPartId";
        public static string EmptyPartName => "EmptyPartName";
        public static string EmptyPartVehicles => "EmptyPartVehicles";
        public static string EmptyBrand => "EmptyBrand";
        public static string EmptyCountry => "EmptyCountry";
        public static string EmptyUnit => "EmptyUnit";
        public static string EmptyProductLimitation => "EmptyProductLimitation";
        #endregion

        #region Invalid
        public static string InvalidBirthYear => "InvalidBirthYear";
        public static string InvalidMonth => "InvalidMonth";
        public static string InvalidCalendarDay => "InvalidCalendarDay";
        public static string InvalidImageFileFormat => "InvalidImageFileFormat";
        public static string InvalidPostalCode => "InvalidPostalCode";
        public static string InvalidMobilePhoneNumber => "InvalidMobilePhoneNumber";
        public static string InvalidParameters => "InvalidParameters";
        public static string InvalidYear => "InvalidYear";
        public static string InvalidPersianDateFormat => "InvalidPersianDateFormat";
        public static string InvalidTelePhoneNumber => "InvalidTelePhoneNumber";
        #endregion

        #region CharacterLimitation
        public static string JustPersianCharacterFirstName => "JustPersianCharacterFirstName";
        public static string JustPersianCharacterLastName => "JustPersianCharacterLastName";
        public static string JustPersianCharacterCityName => "JustPersianCharacterCityName";
        public static string JustPersianCharacterProvinceName => "JustPersianCharacterProvinceName";
        public static string JustPersianOrNumericCharacterStreetName => "JustPersianOrNumericCharacterStreetName";
        public static string JustPersianOrNumericCharacterAlleyName => "JustPersianOrNumericCharacterAlleyName";
        public static string JustPersianCharacterReceiverName => "JustPersianCharacterReceiverName";
        public static string JustNumericCharacterPostalCode => "JustNumericCharacterPostalCode";
        public static string JustNumericCharacterMobilePhoneNumber => "JustNumericCharacterMobilePhoneNumber";
        public static string JustNumericCharacterTelePhoneNumber => "JustNumericCharacterTelePhoneNumber";
        public static string JustNumericCharacterNationalCode => "JustNumericCharacterNationalCode";
        #endregion

        #region NotFound
        public static string NotFoundUser => "NotFoundUser";
        public static string NotFoundAddress => "NotFoundAddress";
        public static string NotFoundProduct => "NotFoundProduct";
        public static string NotFoundCart => "NotFoundCart";
        public static string NotFoundOrder => "NotFoundOrder";
        public static string NotFoundProductInOrder => "NotFoundProductInOrder";
        public static string NotFoundFile => "NotFoundFile";
        public static string NotFoundUserWithPhoneNumber => "NotFoundUserWithPhoneNumber";
        public static string NotFoundPart => "NotFoundPart";
        public static string NotFoundBrand => "NotFoundBrand";
        public static string NotFoundCountry => "NotFoundCountry";
        public static string NotFoundUnit => "NotFoundUnit";
        #endregion

        #region Other
        public static string ZeroProductRequested => "ZeroProductRequested";
        public static string AddressNotRelatedToUser => "AddressNotRelatedToUser";
        public static string CartNotRelatedToUser => "CartNotRelatedToUser";
        public static string ProductPriceOrQtyHasChanged => "ProductPriceOrQtyHasChanged";
        public static string NotEnoughCredit => "NotEnoughCredit";
        public static string FinishedValidationCodeTime => "FinishedValidationCodeTime";
        public static string NotCreatingUser => "NotCreatingUser";
        public static string NotRegisteredUserPhoneNumber => "NotRegisteredUserPhoneNumber";
        #endregion

        #endregion

        #region SuccessMessage
        public static string SuccessfullyEditPersonalInformation => "SuccessfullyEditPersonalInformation";
        public static string SuccessfullyCreateOrder => "SuccessfullyCreateOrder";
        public static string SuccessfullyClearPendingToPayOrders => "SuccessfullyClearPendingToPayOrders";
        public static string SuccessfullyCreatePayment => "SuccessfullyCreatePayment";
        public static string SuccessfullyGetPersonalInformation => "SuccessfullyGetPersonalInformation";
        public static string SuccessfullyCreateProfile => "SuccessfullyCreateProfile";
        public static string SuccessfullyAddProductToOrder => "SuccessfullyAddProductToOrder";
        public static string SuccessfullyGetOrder => "SuccessfullyGetOrder";
        public static string SuccessfullyDeleteOrderProduct => "SuccessfullyDeleteOrderProduct";
        public static string SuccessfullySaveOrderDetail => "SuccessfullySaveOrderDetail";
        public static string SuccessfullyUpdateOrderDetail => "SuccessfullyUpdateOrderDetail";
        public static string SuccessfullyGetPendingOrder => "SuccessfullyGetPendingOrder";
        public static string SuccessfullyDeleteOrder => "SuccessfullyDeleteOrder";
        public static string SuccessfullyUpdateOrder => "SuccessfullyUpdateOrder";
        public static string SuccessfullyGetOrders => "SuccessfullyGetOrders";
        public static string SuccessfullyGetProductsInfos => "SuccessfullyGetProductsInfos";
        public static string SuccessfullyGetInProcessOrders => "SuccessfullyGetInProcessOrders";
        public static string SuccessfullyGetCanceledOrders => "SuccessfullyGetCanceledOrders";
        public static string SuccessfullyGetReturnedOrders => "SuccessfullyGetReturnedOrders";
        public static string SuccessfullyGetPendingOrders => "SuccessfullyGetPendingOrders";
        public static string SuccessfullyGetFailedOrders => "SuccessfullyGetFailedOrders";
        public static string SuccessfullyGetSendingOrders => "SuccessfullyGetSendingOrders";
        #endregion

        #region LogicalError
        public static string ProductQtyOrPriceChanged => "ProductQtyOrPriceChanged";
        #endregion

        #region FaileMessage
        public static string FailedCreateOrder => "FailedCreateOrder";
        public static string FailedPay => "FailedPay";
        public static string FailedClearPendingToPayOrders => "FailedClearPendingToPayOrders";
        public static string FailedAttachPaymentToOrder => "FailedAttachPaymentToOrder";
        public static string FailedCreatePayment => "FailedCreatePayment";
        public static string FailedDeleteOrder => "FailedDeleteOrder";
        public static string FailedReturnOrder => "FailedReturnOrder";
        public static string FailedGetOrderProductsInfo => "FailedGetOrderProductsInfo";
        public static string FailedUpdateOrder => "FailedUpdateOrder";
        public static string FailedGetFailedOrders => "FailedGetFailedOrders";
        public static string FailedGetOrders => "FailedGetOrders";
        public static string FailedGetPendingOrders => "FailedGetPendingOrders";
        public static string FailedGetPendingOrder => "FailedGetPendingOrder";
        public static string FailedGetCanceledOrders => "FailedGetCanceledOrders";
        public static string FailedGetInProcessOrder => "FailedGetInProcessOrder";
        public static string FailedGetOrder => "FailedGetOrder";
        public static string FailedGetMostBuyProducts => "FailedGetMostBuyProducts";
        public static string FailedGetReturnedOrders => "FailedGetReturnedOrders";
        public static string FailedGetSendingOrders => "FailedGetSendingOrders";
        public static string FailedGetPersonalInformation => "FailedGetPersonalInformation";
        public static string FailedDeleteCartProduct => "FailedDeleteCartProduct";
        public static string FailedDeleteOrderProduct => "FailedDeleteOrderProduct";
        public static string FailedCreateProfile => "FailedCreateProfile";
        public static string FailedCreateUser => "FailedCreateUser";
        public static string WrongValidationCode => "WrongValidationCode";
        public static string FailedUpdateUser => "FailedUpdateUser";
        public static string FailedSaveOrderHeader => "FailedSaveOrderHeader";
        public static string FailedSaveOrderDetail => "FailedSaveOrderDetail";
        public static string FailedUpdateOrderDetail => "FailedUpdateOrderDetail";
        public static string FailedCheckProfile => "FailedCheckProfile";
        public static string FailedAddProductToCart => "FailedAddProductToCart";
        public static string FailedUpdateCart => "FailedUpdateCart";
        public static string FailConfirmPayment => "FailConfirmPayment";
        #endregion

        #region InformationMessage

        #region Already
        public static string AlreadyProfileExits => "AlreadyProfileExits";
        public static string AlreadyUserExits => "AlreadyUserExits";
        public static string AlreadyUserWithThisMobilePhoneNumberExists => "AlreadyUserWithThisMobilePhoneNumberExists";
        public static string AlreadyUserWithThisEmailAddressExists => "AlreadyUserWithThisEmailAddressExists";
        #endregion

        #region Zero
        public static string ZeroOrders => "ZeroOrders";
        public static string ZeroInProcessOrders => "ZeroInProcessOrders";
        public static string ZeroProductsInfos => "ZeroProductsInfos";
        public static string ZeroCanceledOrders => "ZeroCanceledOrders";
        public static string ZeroReturnedOrders => "ZeroReturnedOrders";
        public static string ZeroPendingOrders => "ZeroPendingOrders";
        public static string ZeroFailedOrders => "ZeroFailedOrders";
        public static string ZeroSendingOrders => "ZeroSendingOrders";
        #endregion

        #endregion

        #region API
        public static string APISuccess => "APISuccess";
        public static string APIServerError => "APIServerError";
        public static string APIBadRequest => "APIBadRequest";
        public static string APINotFound => "APINotFound";
        public static string APIListEmpty => "APIListEmpty";
        public static string APILogicError => "APILogicError";
        public static string APIUnAuthorized => "APIUnAuthorized";

        public static string IsSuccess => "IsSuccess";
        #endregion
    }
}