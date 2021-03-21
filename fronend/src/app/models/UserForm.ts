export class UserForm {
    public UserName?: string;
    public ComplaintTitle?: string;
    public IsRecurring?: string;
    public ComplaintDetails?:string;
    public UserId?:number;
    public StatusId?:number;
    public StatusTitle?:string;
    public FormId?:number;
    public LogDate?:Date
    public Complaints: string[] = []
}