var ManageService = (function () {
    function ManageService(_idNumeric) {
        this._idNumeric = _idNumeric;
        this.rowActions = ["update", "delete"];
    }
    ManageService.prototype.getEndPoint = function (path, id, ignoreEmpty) {
        var result = this.endPoint + "/" + path;
        if (!id && this._idNumeric && !ignoreEmpty) {
            result += "/0";
        }
        else {
            result += id ? "/" + id : "";
        }
        return result;
    };
    return ManageService;
}());
export { ManageService };
//# sourceMappingURL=manage.service.js.map