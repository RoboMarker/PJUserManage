//import IMenu from '../interfaces';

export class Menu 
{
    constructor(MenuId :Number,MenuName :String,Status :Number,MenuType :Number
        ,PermissionsId :String,CustomizedUserId :String,MenuPermissions :[]){
        this.MenuId=MenuId;
        this.MenuName=MenuName;
        this.Status=Status;
        this.MenuType=MenuType;
        this.PermissionsId=PermissionsId;
        this.CustomizedUserId=CustomizedUserId;
        this.MenuPermissions=MenuPermissions;
    }
    private MenuId :Number;
    private MenuName:String;
    private Status:Number; 
    private MenuType :Number;
    private PermissionsId :String;
    private CustomizedUserId :String;
    private MenuPermissions :[];
}