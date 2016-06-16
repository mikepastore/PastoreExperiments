using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMAPI
{
    public enum AgendaVersion
{
    	Board=4,
	Full=2,
	Public=1,
	Staff=3, 
    Undefined=255
}
public enum AppointmentType
{
    	Election=1,
	Board=2,
	Official=3,
	External=4, 
    Undefined=255
}
public enum AttachmentIncludeOption
{
    	Include=30,
	None=10,
	ReferenceOnly=20, 
    Undefined=255
}
public enum AttachmentType
{
    	FileAttachment=10,
	LinkedFile=20,
	Note=30,
	WebAddress=40, 
    Undefined=255
}
public enum AttachmentVisibility
{
    	Confidential=50,
	Departmental=40,
	Internal=60,
	Private=20,
	Public=80, 
    Undefined=255
}
public enum AttendanceStatus
{
    	Present=10,
	Late=20,
	Absent=30,
	Excused=40,
	Remote=50, 
    Undefined=255
}
public enum CommunicationStatus
{
    	New=10,
	Scheduled=50,
	Announced=110, 
    Undefined=255
}
public enum ContentFileType
{
    	Logo=10,
	UserPortrait=20,
	UserSignature=30,
	WebPortalResource=40,
	AnnotationStamp=50,
	ApplicationAvatar=60, 
    Undefined=255
}
public enum Ethnicity
{
    	HispanicorLatino=1,
	AmericanIndianorAlaskaNative=2,
	Asian=3,
	BlackorAfricanAmerican=4,
	NativeHawaiianorPacificIslander=5,
	White=6,
	Twoormoreraces=7,
	Other=8, 
    Undefined=255
}
public enum FlagStatus
{
    	Blue=20,
	Complete=100,
	Green=30,
	Red=10,
	White=40,
	Yellow=50, 
    Undefined=255
}
public enum FullNumResetPolicy
{
    	CalendarYear=10,
	Month=20,
	Day=30,
	OperatingYear=40,
	Never=50, 
    Undefined=255
}
public enum Gender
{
    	Male=1,
	Female=2,
	Other=3, 
    Undefined=255
}
public enum LegalNoticeStatus
{
    	Draft=10,
	Ready=20,
	Published=110, 
    Undefined=255
}
public enum MediaEncoderPreset
{
    	Standard=10,
	HighDefinition=20,
	AudioOnly=30, 
    Undefined=255
}
public enum MediaEncoderStatus
{
    	Initialize=10,
	Starting=20,
	Paused=30,
	Recording=40,
	Stopping=50,
	Stopped=60,
	Error=70,
	Disconnected=80,
	Live24x7=90, 
    Undefined=255
}
public enum MediaStatus
{
    	Archived=200,
	Available=100,
	Processing=50,
	Recording=40,
	Starting=20,
	Stopped=220,
	UploadError=65,
	Uploaded=70,
	Uploading=60, 
    Undefined=255
}
public enum MediaVaultStatus
{
    	Available=100,
	Downloading=40,
	Unavailable=20, 
    Undefined=255
}
public enum MeetingStatus
{
    	Scheduled=10,
	Cancelled=110,
	Closed=120, 
    Undefined=255
}
public enum MinutesItemType
{
    	LegislativeFiles=10,
	PublicHearing=20,
	MinutesAcceptance=30,
	Communication=40,
	Statement=50,
	Motion=60,
	Section=70,
	RollCall=80,
	Attachment=90,
	ConsentAgenda=100,
	SpeakerSignup=110, 
    Undefined=255
}
public enum MinutesStatus
{
    	Draft=10,
	Generated=20,
	Finalized=25,
	ScheduledtoAccept=30,
	Tabled=40,
	Accepted=110, 
    Undefined=255
}
public enum OutlineFormat
{
    	Automatic=10,
	Roman=20,
	RomanLowercase=25,
	Alpha=40,
	AlphaLowercase=45,
	Numeric=60, 
    Undefined=255
}
public enum PublicHearingStatus
{
    	New=10,
	Scheduled=20,
	Adjourned=30,
	Closed=110, 
    Undefined=255
}
public enum RecipientType
{
    	Recipient=10,
	User=20,
	WebUser=30, 
    Undefined=255
}
public enum RecordType
{
    	Agenda=30,
	Application=150,
	ApplicationWorkflowStep=170,
	Appointment=190,
	Attachment=70,
	BoardMember=200,
	Communication=110,
	ContentFile=100,
	CustomField=182,
	Department=180,
	Email=211,
	LegalNotice=50,
	LegislativeFile=10,
	Media=90,
	MediaEncoder=140,
	Minutes=40,
	OtherDocument=60,
	Position=181,
	PublicHearing=20,
	Settings=210,
	Task=80,
	Template=120,
	TemplateSet=125,
	Transcript=130,
	UserAccount=160, 
    Undefined=255
}
public enum ResLinkType
{
    	Amend=10,
	Replace=20,
	Rescind=30,
	Origin=40,
	Link=50,
	Reference=60, 
    Undefined=255
}
public enum ResolutionApprovalStatus
{
    	Pending=10,
	Rejected=110,
	Completed=120,
	Skipped=130, 
    Undefined=255
}
public enum ResolutionStatus
{
    	Draft=10,
	Submitted=20,
	Rejected=30,
	Reviewed=40,
	Scheduled=50,
	Tabled=70,
	Abandoned=110,
	Withdrawn=120,
	Defeated=130,
	Adopted=140,
	Completed=150,
	Amended=200,
	Replaced=210,
	Rescinded=220, 
    Undefined=255
}
public enum SecurityLockOut
{
    	AccountExceededInactivityLimit=10,
	Toomanyfailedloginattempts=20,
	UserAccountExpired=30, 
    Undefined=255
}
public enum Severity
{
    	Info=10,
	Warning=20,
	Error=30, 
    Undefined=255
}
public enum TaskPriority
{
    	High=60,
	Low=20,
	Normal=40, 
    Undefined=255
}
public enum TemplateType
{
    	NewLegislativeFile=10,
	HeaderLegislativeFile=15,
	InsertLegislativeFile=20,
	HeaderAgenda=30,
	HeaderMinutes=40,
	HeaderLetter=50,
	InsertSignOffSheet=55,
	HeaderArchiveIndex=60,
	InsertLegalNotice=75,
	NewMinutesStatement=80,
	NewMinutesMotion=85,
	InsertCommunication=90,
	InsertPublicHearing=95,
	InsertSection=100,
	InsertMinutesAcceptance=105,
	InsertStatement=110,
	InsertMotion=115,
	InsertRollCall=120,
	NewLegislativeDiscussion=125,
	InsertConsentAgenda=130,
	Enhanced=135,
	NewLegislativeComments=140,
	NewLegislativeBody=145,
	HeaderApplication=150,
	AppDepartmentIntendWithRecommendations=151,
	AppDepartmentIntendWithNoRecommendations=152,
	AppPositionIntendWithRecommendations=153,
	ApplicationQualifications=154,
	ApplicationWorkflow=155,
	HeaderAppointment=160,
	AppointmentBoard=161, 
    Undefined=255
}
public enum TranscodeStatus
{
    	Unavailable=10,
	TranscodingLocally=15,
	Submitted=20,
	Transferring=30,
	WaitingforEncoder=40,
	Processing=50,
	Saving=60,
	NeedsConcat=70,
	Skipped=110,
	Error=120,
	Available=150, 
    Undefined=255
}
public enum UserType
{
    	NormalUser=10,
	WebUserPublic=20,
	SystemUser=30,
	Service=40, 
    Undefined=255
}
public enum Visibility
{
    	Global=60,
	Group=40,
	User=20, 
    Undefined=255
}
public enum Vote
{
    	YesAye=10,
	NoNay=20,
	Abstain=30,
	Absent=40,
	Away=50,
	Excused=60,
	Recused=70, 
    Undefined=255
}
public enum VoteResultRouting
{
    	Final=10,
	Tabled=20,
	Referred=30, 
    Undefined=255
}
public enum VoterRole
{
    	Mover=10,
	Seconder=20,
	Voter=30, 
    Undefined=255
}
public enum WebUploadVersions
{
    	Both=30,
	Full=10,
	Public=20, 
    Undefined=255
}
public enum WorkItemType
{
    	AttachReview=30,
	AttachSign=50,
	ESignature=60,
	Meeting=20,
	Review=10,
	Sign=40, 
    Undefined=255
}

}
