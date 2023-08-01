interface IMenu {
     MenuId: String;
     MenuName: String;
     Status?: Number;
     MenuType?: Number;
     PermissionsId?: String;
     CustomizedUserId?: String;
     MenuPermissions?: [];
}
export default IMenu;