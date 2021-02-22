export class LogList { 
    id:string; 
    changeLogType:string;
    content:string;
    changeLogTime:Date;
    userId:string;
}

export enum ChangeLogType {
    NewRelease = "New Release",
    Update = "Update",
    Fix = "Fix"
}