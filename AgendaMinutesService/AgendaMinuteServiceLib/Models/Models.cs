using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMAPI
{
    public class AccessLog {
     public Int32? RecordTypeID { get;set; }
     public Int64? ID { get;set; }
     public Int32? UserID { get;set; }
     public Int32? TimesOpened { get;set; }
     public DateTime? FirstAccess { get;set; }
     public DateTime? LastAccess { get;set; }
     public AMAPI.RecordType RecordTypes { get;set; }
     public UserAccount User { get;set; }
}

public class Agenda {
     public Int32? AgendaID { get;set; }
     public Int32? MeetingID { get;set; }
     public Int32? OutlineFormatID { get;set; }
     public System.String FileFormat { get;set; }
     public System.String FileFormatPublic { get;set; }
     public System.String FileFormatBoard { get;set; }
     public System.String FileFormatStaff { get;set; }
     public DateTime? FileUpdated { get;set; }
     public DateTime? FileUpdatedPublic { get;set; }
     public DateTime? FileUpdatedBoard { get;set; }
     public DateTime? FileUpdatedStaff { get;set; }
     public DateTime? Generated { get;set; }
     public DateTime? WebUpload { get;set; }
     public Int32? WebUploadVersions { get;set; }
     public DateTime? Finalized { get;set; }
     public DateTime? Updated { get;set; }
     public Int32? UpdatedUserID { get;set; }
     public Boolean? AutoLockAddedDocuments { get;set; }
     public Meeting Meeting { get;set; }
     public AMAPI.OutlineFormat OutlineFormats { get;set; }
     public UserAccount UpdatedUser { get;set; }
     public AMAPI.WebUploadVersions WebUploadVersion { get;set; }
}

public class AgendaItem {
     public Int64? AgendaItemID { get;set; }
     public Int32? AgendaID { get;set; }
     public Int64? ParentItemID { get;set; }
     public Int16? ItemNum { get;set; }
     public Int16? Sort { get;set; }
     public Boolean? DoNotNumber { get;set; }
     public Boolean? ContinuousNumbering { get;set; }
     public Int32? OutlineFormatID { get;set; }
     public DateTime? Start { get;set; }
     public Int32? Duration { get;set; }
     public Int16? PageNum { get;set; }
     public Int16? PageNumAppendix { get;set; }
     public Int16? PageNumPublic { get;set; }
     public Int16? PageNumPublicAppendix { get;set; }
     public Int16? PageNumBoard { get;set; }
     public Int16? PageNumBoardAppendix { get;set; }
     public Int16? PageNumStaff { get;set; }
     public Int16? PageNumStaffAppendix { get;set; }
     public Int32? MinutesItemTypeID { get;set; }
     public Int32? ResolutionID { get;set; }
     public Int32? PublicHearingID { get;set; }
     public Int32? CommunicationID { get;set; }
     public Int32? AcceptMinutesID { get;set; }
     public Int64? AttachmentID { get;set; }
     public Int32? SpeakerSignupID { get;set; }
     public System.String Title { get;set; }
     public Boolean? GUIExpanded { get;set; }
     public System.String FileFormat { get;set; }
     public DateTime? FileUpdated { get;set; }
     public Int16? TagID { get;set; }
     public Int32? SpeakerSignupPolicyID { get;set; }
     public Boolean? IsSpeakerSignupDefault { get;set; }
     public Agenda Agenda { get;set; }
     public AgendaItem ParentItem { get;set; }
     public Attachment Attachment { get;set; }
     public Communication Communication { get;set; }
     public Minutes AcceptMinute { get;set; }
     public AMAPI.MinutesItemType MinutesItemTypes { get;set; }
     public AMAPI.OutlineFormat OutlineFormats { get;set; }
     public PublicHearing PublicHearing { get;set; }
     public Resolution Resolution { get;set; }
     public SpeakerSignup SpeakerSignup { get;set; }
     public Tag Tag { get;set; }
}

public class AgendaUpdateRequest {
     public Int32? AgendaUpdateRequestID { get;set; }
     public Int32? AgendaID { get;set; }
     public Int64? AgendaItemID { get;set; }
     public System.String CreatorComment { get;set; }
     public Int32? ClerkUserID { get;set; }
     public System.String ClerkComments { get;set; }
     public DateTime? Reviewed { get;set; }
     public Int32? CreatedUserID { get;set; }
     public DateTime? Created { get;set; }
     public Agenda Agenda { get;set; }
     public AgendaItem AgendaItem { get;set; }
     public UserAccount CreatedUser { get;set; }
     public UserAccount ClerkUser { get;set; }
}

public class Attachment {
     public Int64? AttachmentID { get;set; }
     public Int32? ResolutionID { get;set; }
     public Int16? Sort { get;set; }
     public Int32? AttachmentTypeID { get;set; }
     public Int32? AttachmentCategoryID { get;set; }
     public System.String Title { get;set; }
     public System.String FormalNumber { get;set; }
     public Int32? AttachmentVisibilityID { get;set; }
     public Int32? IncludeAgendaID { get;set; }
     public Int32? IncludeLetterID { get;set; }
     public System.String IncludeRange { get;set; }
     public System.String Path { get;set; }
     public System.String FileFormat { get;set; }
     public DateTime? FileUpdated { get;set; }
     public Int64? FileSize { get;set; }
     public DateTime? Locked { get;set; }
     public Int32? LockedUserID { get;set; }
     public Int32? DepartmentID { get;set; }
     public Int16? RevisionNum { get;set; }
     public DateTime? Created { get;set; }
     public Int32? CreatedUserID { get;set; }
     public DateTime? Updated { get;set; }
     public Int32? UpdatedUserID { get;set; }
     public Int32? ExternalKeyID { get;set; }
     public AMAPI.AttachmentIncludeOption IncludeAgendas { get;set; }
     public AMAPI.AttachmentIncludeOption IncludeLetters { get;set; }
     public AMAPI.AttachmentType AttachmentTypes { get;set; }
     public AMAPI.AttachmentVisibility AttachmentVisibilities { get;set; }
     public Department Department { get;set; }
     public List<ExternalKey> ExternalKeies { get;set; }
     public Resolution Resolution { get;set; }
     public UserAccount LockedUser { get;set; }
     public UserAccount CreatedUser { get;set; }
     public UserAccount UpdatedUser { get;set; }
}

public class AttachmentCategory {
     public Int32? AttachmentCategoryID { get;set; }
     public System.String AttachmentCategoryName { get;set; }
     public System.String FullNumFormat { get;set; }
     public System.String NumPrefix { get;set; }
     public Int32? FullNumResetPolicyID { get;set; }
     public AMAPI.FullNumResetPolicy FullNumResetPolicies { get;set; }
}

public class Attendance {
     public Int64? AttendanceID { get;set; }
     public Int32? MeetingID { get;set; }
     public Int32? UserID { get;set; }
     public Int32? AttendanceStatusID { get;set; }
     public Int16? Sort { get;set; }
     public Boolean? Voter { get;set; }
     public System.String FullName { get;set; }
     public System.String Title { get;set; }
     public System.String Organization { get;set; }
     public DateTime? Arrived { get;set; }
     public DateTime? Departed { get;set; }
     public AMAPI.AttendanceStatus AttendanceStatu { get;set; }
     public Meeting Meeting { get;set; }
     public UserAccount User { get;set; }
}

public class BudgetSource {
     public Int32? BudgetSourceID { get;set; }
     public System.String BudgetSourceName { get;set; }
     public System.String AccountNum { get;set; }
     public Boolean? Inactive { get;set; }
}

public class CategoryWorkItem {
     public Int32? CategoryWorkItemID { get;set; }
     public Int32? ResolutionCategoryID { get;set; }
     public Int32? FromDepartmentID { get;set; }
     public Int32? ProjectID { get;set; }
     public Int32? FunctionalCategoryID { get;set; }
     public Int16? LegiFileTypeID { get;set; }
     public Int32? StageNum { get;set; }
     public Int32? WorkItemTypeID { get;set; }
     public System.String Description { get;set; }
     public System.String Instructions { get;set; }
     public Int32? DepartmentID { get;set; }
     public Int32? UserID { get;set; }
     public System.String SpecialDestination { get;set; }
     public DateTime? RelativeDueDate { get;set; }
     public Int16? LegiLookupID { get;set; }
     public Department Department { get;set; }
     public Department FromDepartment { get;set; }
     public List<FunctionalCategory> FunctionalCategories { get;set; }
     public LegiFileType LegiFileType { get;set; }
     public LegiLookup LegiLookup { get;set; }
     public Project Project { get;set; }
     public List<ResolutionCategory> ResolutionCategories { get;set; }
     public UserAccount User { get;set; }
     public AMAPI.WorkItemType WorkItemTypes { get;set; }
}

public class Communication {
     public Int32? CommunicationID { get;set; }
     public Int32? MeetingID { get;set; }
     public Int32? CommunicationTypeID { get;set; }
     public Int32? CommunicationStatusID { get;set; }
     public DateTime? Received { get;set; }
     public System.String Subject { get;set; }
     public System.String Details { get;set; }
     public DateTime? CalendarStart { get;set; }
     public DateTime? CalendarEnd { get;set; }
     public System.String FileFormat { get;set; }
     public DateTime? FileUpdated { get;set; }
     public AMAPI.CommunicationStatus CommunicationStatu { get;set; }
     public CommunicationType CommunicationType { get;set; }
     public Meeting Meeting { get;set; }
}

public class CommunicationType {
     public Int32? CommunicationTypeID { get;set; }
     public System.String CommunicationTypeName { get;set; }
     public Boolean? Inactive { get;set; }
}

public class ContentFile {
     public Int32? ContentFileID { get;set; }
     public Int32? ContentFileTypeID { get;set; }
     public System.String ContentFileTitle { get;set; }
     public System.String FileFormat { get;set; }
     public DateTime? FileUpdated { get;set; }
     public Boolean? Inactive { get;set; }
     public AMAPI.ContentFileType ContentFileTypes { get;set; }
}

public class Department {
     public Int32? DepartmentID { get;set; }
     public Int32? ParentDepartmentID { get;set; }
     public System.String DepartmentName { get;set; }
     public System.String DepartmentFormalName { get;set; }
     public System.String Initials { get;set; }
     public Int16? OrgGroupTypeID { get;set; }
     public Boolean? MeetingGroup { get;set; }
     public System.String Address1 { get;set; }
     public System.String Address2 { get;set; }
     public System.String AddressCity { get;set; }
     public System.String AddressState { get;set; }
     public System.String AddressPostal { get;set; }
     public System.String Phone { get;set; }
     public System.String Fax { get;set; }
     public System.String Message { get;set; }
     public Int32? OrganizerUserID { get;set; }
     public Int32? ChairpersonUserID { get;set; }
     public Int32? TemplateSetID { get;set; }
     public Int32? VotePassBasisID { get;set; }
     public Int32? LetterDistributionListID { get;set; }
     public Int16? AppointmentTypeID { get;set; }
     public Int32? AppointedByDepartmentID { get;set; }
     public Int32? AppointedByUserID { get;set; }
     public System.String AppointedByExternalAgency { get;set; }
     public System.String MeetingFrequency { get;set; }
     public System.String AffectingLegislation { get;set; }
     public Int32? TermDuration { get;set; }
     public Int32? TermsMaximumNumber { get;set; }
     public Int32? TermBreakMonth { get;set; }
     public Boolean? TermsNumberNotLimited { get;set; }
     public System.String RefText1 { get;set; }
     public System.String RefText2 { get;set; }
     public System.String RefText3 { get;set; }
     public System.String RefText4 { get;set; }
     public System.String RefText5 { get;set; }
     public Boolean? Inactive { get;set; }
     public DateTime? Created { get;set; }
     public DateTime? Updated { get;set; }
     public Int32? UpdatedByUserID { get;set; }
     public Boolean? IsLifeTime { get;set; }
     public Department AppointedByDepartment { get;set; }
     public UserAccount AppointedByUser { get;set; }
     public AMAPI.AppointmentType AppointmentTypes { get;set; }
     public Department ParentDepartment { get;set; }
     public DistributionList LetterDistributionList { get;set; }
     public OrgGroupType OrgGroupType { get;set; }
     public TemplateSet TemplateSet { get;set; }
     public UserAccount UpdatedByUser { get;set; }
     public UserAccount OrganizerUser { get;set; }
     public UserAccount ChairpersonUser { get;set; }
     public VotePassBasis VotePassBasi { get;set; }
}

public class DistributionList {
     public Int32? DistributionListID { get;set; }
     public System.String DistributionListName { get;set; }
     public Boolean? AllowWebSignup { get;set; }
     public Int32? OwnerDepartmentID { get;set; }
     public Boolean? Inactive { get;set; }
     public Department OwnerDepartment { get;set; }
}

public class DistributionListRecipient {
     public Int32? DistributionListID { get;set; }
     public Int32? RecipientID { get;set; }
     public DistributionList DistributionList { get;set; }
     public Recipient Recipient { get;set; }
}

public class DocRevision {
     public Int64? DocRevisionID { get;set; }
     public Int32? ResolutionID { get;set; }
     public Int64? AttachmentID { get;set; }
     public Int32? TemplateID { get;set; }
     public Int16? RevisionNum { get;set; }
     public DateTime? ValidThrough { get;set; }
     public System.String FileFormat { get;set; }
     public DateTime? FileUpdated { get;set; }
     public Int64? FileSize { get;set; }
     public Int32? UserID { get;set; }
     public Attachment Attachment { get;set; }
     public Resolution Resolution { get;set; }
     public Template Template { get;set; }
     public UserAccount User { get;set; }
}

public class Document {
     public Int64? DocumentID { get;set; }
     public Int16? DocumentTypeID { get;set; }
     public System.String Title { get;set; }
     public System.String RefText1 { get;set; }
     public System.String RefText2 { get;set; }
     public System.String RefText3 { get;set; }
     public Int32? RefLookup1 { get;set; }
     public Int32? RefLookup2 { get;set; }
     public Int64? RefNum1 { get;set; }
     public Int64? RefNum2 { get;set; }
     public DateTime? RefDate1 { get;set; }
     public DateTime? RefDate2 { get;set; }
     public System.String RefMemo1 { get;set; }
     public System.String RefMemo2 { get;set; }
     public System.String FileFormat { get;set; }
     public DateTime? FileUpdated { get;set; }
     public DateTime? Created { get;set; }
     public Int32? CreatedUserID { get;set; }
     public DateTime? Updated { get;set; }
     public Int32? UpdatedUserID { get;set; }
     public Int32? RefDepartment { get;set; }
     public Int32? RefUser { get;set; }
     public List<Department> RefDepartments { get;set; }
     public List<DocumentLookup> RefLookup1s { get;set; }
     public List<DocumentLookup> RefLookup2s { get;set; }
     public List<UserAccount> RefUsers { get;set; }
     public DocumentType DocumentType { get;set; }
     public UserAccount CreatedUser { get;set; }
     public UserAccount UpdatedUser { get;set; }
}

public class DocumentLookup {
     public Int32? DocumentLookupID { get;set; }
     public Int16? DocumentTypeID { get;set; }
     public Int32? RefNum { get;set; }
     public System.String DocumentLookupName { get;set; }
     public Boolean? Inactive { get;set; }
     public DocumentType DocumentType { get;set; }
}

public class DocumentMultiSelect {
     public Int32? DocumentMultiSelectID { get;set; }
     public Int32? DocumentLookupID { get;set; }
     public Int32? DocumentID { get;set; }
     public DocumentLookup DocumentLookup { get;set; }
}

public class DocumentType {
     public Int16? DocumentTypeID { get;set; }
     public System.String DocumentTypeName { get;set; }
     public System.String PluralName { get;set; }
     public System.String FileFormat { get;set; }
     public Boolean? MultipleFileFormats { get;set; }
     public Boolean? RefText1Use { get;set; }
     public System.String RefText1Name { get;set; }
     public Boolean? RefText1Require { get;set; }
     public Boolean? RefText2Use { get;set; }
     public System.String RefText2Name { get;set; }
     public Boolean? RefText2Require { get;set; }
     public Boolean? RefText3Use { get;set; }
     public System.String RefText3Name { get;set; }
     public Boolean? RefText3Require { get;set; }
     public Boolean? RefLookup1Use { get;set; }
     public System.String RefLookup1Name { get;set; }
     public Boolean? RefLookup1Require { get;set; }
     public Boolean? RefLookup2Use { get;set; }
     public System.String RefLookup2Name { get;set; }
     public Boolean? RefLookup2Require { get;set; }
     public Boolean? RefNum1Use { get;set; }
     public System.String RefNum1Name { get;set; }
     public Boolean? RefNum1Require { get;set; }
     public Boolean? RefNum2Use { get;set; }
     public System.String RefNum2Name { get;set; }
     public Boolean? RefNum2Require { get;set; }
     public Boolean? RefDate1Use { get;set; }
     public System.String RefDate1Name { get;set; }
     public Boolean? RefDate1Require { get;set; }
     public Boolean? RefDate1Time { get;set; }
     public Boolean? RefDate2Use { get;set; }
     public System.String RefDate2Name { get;set; }
     public Boolean? RefDate2Require { get;set; }
     public Boolean? RefDate2Time { get;set; }
     public Boolean? RefMemo1Use { get;set; }
     public System.String RefMemo1Name { get;set; }
     public Boolean? RefMemo1Require { get;set; }
     public Boolean? RefMemo2Use { get;set; }
     public System.String RefMemo2Name { get;set; }
     public Boolean? RefMemo2Require { get;set; }
     public Boolean? Private { get;set; }
     public Boolean? ReadOnly { get;set; }
     public Boolean? Inactive { get;set; }
     public Boolean? RefMultiSelect1Use { get;set; }
     public Boolean? RefMultiSelect2Use { get;set; }
     public Boolean? RefDepartmentUse { get;set; }
     public Boolean? RefUserUse { get;set; }
     public Boolean? RefMultiSelect1Require { get;set; }
     public Boolean? RefMultiSelect2Require { get;set; }
     public Boolean? RefDepartmentRequire { get;set; }
     public Boolean? RefUserRequire { get;set; }
     public System.String RefMultiSelect1Name { get;set; }
     public System.String RefMultiSelect2Name { get;set; }
     public System.String RefDepartmentName { get;set; }
     public System.String RefUserName { get;set; }
}

public class EncodingSettings {
     public Int32? EncodingSettingsID { get;set; }
     public Int32? MediaEncoderPresetID { get;set; }
     public Int16? VideoWidth { get;set; }
     public Int16? VideoHeight { get;set; }
     public Int16? Bitrate { get;set; }
     public Boolean? Inactive { get;set; }
     public AMAPI.MediaEncoderPreset MediaEncoderPresets { get;set; }
}

public class ExternalKey {
     public Int32? ExternalKeyID { get;set; }
     public Int32? ExternalSystemID { get;set; }
     public System.String DataType { get;set; }
     public System.String ExternalID { get;set; }
     public System.String Title { get;set; }
}

public class FileFormat {
     public System.String Ext { get;set; }
     public System.String FileFormatName { get;set; }
}

public class FunctionalCategory {
     public Int32? FunctionalCategoryID { get;set; }
     public System.String FunctionalCategoryName { get;set; }
     public Boolean? VisibleAllDepartments { get;set; }
     public Boolean? VisibleAllCategories { get;set; }
     public System.String Description { get;set; }
     public Boolean? Inactive { get;set; }
}

public class LegalNotice {
     public Int32? LegalNoticeID { get;set; }
     public Int32? LegalNoticeTypeID { get;set; }
     public System.String ShortTitle { get;set; }
     public System.String Description { get;set; }
     public Int32? OriginResolutionID { get;set; }
     public DateTime? Publish { get;set; }
     public Int32? LegalNoticeStatusID { get;set; }
     public System.String FileFormat { get;set; }
     public DateTime? FileUpdated { get;set; }
     public AMAPI.LegalNoticeStatus LegalNoticeStatu { get;set; }
     public LegalNoticeType LegalNoticeType { get;set; }
     public Resolution OriginResolution { get;set; }
}

public class LegalNoticeType {
     public Int32? LegalNoticeTypeID { get;set; }
     public System.String LegalNoticeTypeName { get;set; }
     public Int32? DistributionListID { get;set; }
     public Boolean? Inactive { get;set; }
     public DistributionList DistributionList { get;set; }
}

public class LegiFileType {
     public Int16? LegiFileTypeID { get;set; }
     public System.String LegiFileTypeName { get;set; }
     public System.String PluralName { get;set; }
     public Int32? MeetingGroupID { get;set; }
     public System.String NumPrefix { get;set; }
     public System.String UserText1Label { get;set; }
     public Boolean? UserText1Required { get;set; }
     public System.String UserText2Label { get;set; }
     public Boolean? UserText2Required { get;set; }
     public System.String UserLookup1Label { get;set; }
     public Boolean? UserLookup1Required { get;set; }
     public System.String UserLookup2Label { get;set; }
     public Boolean? UserLookup2Required { get;set; }
     public System.String UserLookup3Label { get;set; }
     public Boolean? UserLookup3Required { get;set; }
     public System.String UserLookup4Label { get;set; }
     public Boolean? UserLookup4Required { get;set; }
     public System.String UserDate1Label { get;set; }
     public Boolean? UserDate1Required { get;set; }
     public System.String UserDate2Label { get;set; }
     public Boolean? UserDate2Required { get;set; }
     public System.String UserUser1Label { get;set; }
     public Boolean? UserUser1Required { get;set; }
     public System.String UserUser2Label { get;set; }
     public Boolean? UserUser2Required { get;set; }
     public System.String UserDept1Label { get;set; }
     public Boolean? UserDept1Required { get;set; }
     public System.String UserDept2Label { get;set; }
     public Boolean? UserDept2Required { get;set; }
     public Int32? DiscussionTemplateID { get;set; }
     public Int32? PrintoutTemplateID { get;set; }
     public Int32? AppendixTemplateID { get;set; }
     public Boolean? RequireBody { get;set; }
     public Boolean? RequireProject { get;set; }
     public Boolean? RequireFunctionalCategory { get;set; }
     public Boolean? RequireFinancialImpact { get;set; }
     public Boolean? RequireSponsor { get;set; }
     public System.String FullNumFormat { get;set; }
     public Int32? VotePassBasisID { get;set; }
     public Int32? FullNumResetPolicyID { get;set; }
     public Boolean? Inactive { get;set; }
     public System.String UserMultiSelect1Label { get;set; }
     public Boolean? UserMultiSelect1Required { get;set; }
     public System.String UserMultiSelect2Label { get;set; }
     public Boolean? UserMultiSelect2Required { get;set; }
     public System.String UserMultiSelect3Label { get;set; }
     public Boolean? UserMultiSelect3Required { get;set; }
     public System.String UserMultiSelect4Label { get;set; }
     public Boolean? UserMultiSelect4Required { get;set; }
     public Department MeetingGroup { get;set; }
     public AMAPI.FullNumResetPolicy FullNumResetPolicies { get;set; }
     public Template DiscussionTemplate { get;set; }
     public Template PrintoutTemplate { get;set; }
     public Template AppendixTemplate { get;set; }
     public VotePassBasis VotePassBasi { get;set; }
}

public class LegiLookup {
     public Int16? LegiLookupID { get;set; }
     public Int16? LegiFileTypeID { get;set; }
     public Int16? RefNum { get;set; }
     public System.String LegiLookupName { get;set; }
     public Boolean? Inactive { get;set; }
     public LegiFileType LegiFileType { get;set; }
}

public class Media {
     public Int32? MediaID { get;set; }
     public Int32? MeetingID { get;set; }
     public Int32? MediaEventID { get;set; }
     public Int32? MediaStatusID { get;set; }
     public System.String MediaStatusMessage { get;set; }
     public Int16? MediaEncoderID { get;set; }
     public System.String SourceFormat { get;set; }
     public DateTime? Started { get;set; }
     public Int32? Duration { get;set; }
     public DateTime? Published { get;set; }
     public Int32? TranscodeStatusID { get;set; }
     public Int64? TranscodeID { get;set; }
     public System.String TranscodeFormats { get;set; }
     public Int64? TranscodeTimeLeft { get;set; }
     public Int32? TranscodeProgress { get;set; }
     public System.String TranscodeInfo { get;set; }
     public DateTime? TranscodeStarted { get;set; }
     public DateTime? TranscodeUpdated { get;set; }
     public Int32? LocalVaultStatusID { get;set; }
     public Int32? MediaEncoderPresetID { get;set; }
     public DateTime? Created { get;set; }
     public Int32? CreatedUserID { get;set; }
     public DateTime? Updated { get;set; }
     public Int32? UpdatedUserID { get;set; }
     public MediaEncoder MediaEncoder { get;set; }
     public AMAPI.MediaEncoderPreset MediaEncoderPresets { get;set; }
     public MediaEvent MediaEvent { get;set; }
     public AMAPI.MediaStatus MediaStatu { get;set; }
     public AMAPI.MediaVaultStatus LocalVaultStatu { get;set; }
     public Meeting Meeting { get;set; }
     public AMAPI.TranscodeStatus TranscodeStatu { get;set; }
     public UserAccount CreatedUser { get;set; }
     public UserAccount UpdatedUser { get;set; }
}

public class MediaEncoder {
     public Int16? MediaEncoderID { get;set; }
     public System.String MediaEncoderName { get;set; }
     public System.String NetworkName { get;set; }
     public Int32? BroadcastPort { get;set; }
     public System.String BroadcastURL { get;set; }
     public System.String DirectURL { get;set; }
     public Int32? Status { get;set; }
     public DateTime? StatusUpdated { get;set; }
     public System.String RemoteCommand { get;set; }
     public DateTime? RemoteCommandUpdated { get;set; }
     public System.String Version { get;set; }
     public Int32? SupportAlert { get;set; }
     public Int32? MediaEncoderPresetID { get;set; }
     public System.String DefaultVideoDevice { get;set; }
     public System.String DefaultAudioDevice { get;set; }
     public System.String LocalURI { get;set; }
     public System.String PublicIP { get;set; }
     public Int32? ServiceUserID { get;set; }
     public Boolean? IsEncoder { get;set; }
     public Boolean? IsReplicator { get;set; }
     public Boolean? IsVault { get;set; }
     public Boolean? CanStream24x7 { get;set; }
     public System.String ChannelName { get;set; }
     public Boolean? LiveStream { get;set; }
     public Boolean? AutoPublish { get;set; }
     public Boolean? NormalizeAudio { get;set; }
     public Decimal? AudioGainLevel { get;set; }
     public Boolean? Inactive { get;set; }
     public AMAPI.MediaEncoderPreset MediaEncoderPresets { get;set; }
     public AMAPI.MediaEncoderStatus Statu { get;set; }
     public UserAccount ServiceUser { get;set; }
}

public class MediaEvent {
     public Int32? MediaEventID { get;set; }
     public Int16? MediaEventTypeID { get;set; }
     public DateTime? EventDate { get;set; }
     public System.String Title { get;set; }
     public System.String Description { get;set; }
     public System.String ContentURL { get;set; }
     public System.String FileFormat { get;set; }
     public DateTime? FileUpdated { get;set; }
     public Int64? FileSize { get;set; }
     public MediaEventType MediaEventType { get;set; }
}

public class MediaEventType {
     public Int16? MediaEventTypeID { get;set; }
     public System.String MediaEventTypeName { get;set; }
     public System.String PluralName { get;set; }
     public System.String DateFormat { get;set; }
     public Int16? Sort { get;set; }
     public Boolean? Inactive { get;set; }
}

public class MediaFile {
     public Int32? MediaFileID { get;set; }
     public Int32? MediaID { get;set; }
     public Int32? EncodingSettingID { get;set; }
     public Int64? FileSize { get;set; }
     public DateTime? FileUpdated { get;set; }
     public System.String FileFormat { get;set; }
     public Int64? UploadedBytes { get;set; }
     public EncodingSettings EncodingSetting { get;set; }
     public Media Media { get;set; }
}

public class MediaRouting {
     public Int32? MediaRoutingID { get;set; }
     public Int16? MediaEncoderID { get;set; }
     public Int32? MediaServerTypeID { get;set; }
     public Int32? PrioritySort { get;set; }
     public System.String Subnet { get;set; }
     public System.String Mask { get;set; }
     public System.String MediaURL { get;set; }
     public Int16? DestinationEncoderID { get;set; }
     public Boolean? AutoDetected { get;set; }
     public Boolean? Inactive { get;set; }
     public MediaEncoder MediaEncoder { get;set; }
     public MediaEncoder DestinationEncoder { get;set; }
     public MediaServerType MediaServerType { get;set; }
}

public class MediaServerType {
     public Int32? MediaServerTypeID { get;set; }
     public System.String MediaServerTypeName { get;set; }
}

public class Meeting {
     public Int32? MeetingID { get;set; }
     public DateTime? MeetingDate { get;set; }
     public DateTime? ResolutionDueDate { get;set; }
     public Int32? MeetingTypeID { get;set; }
     public Int32? MeetingLocationID { get;set; }
     public Int32? MeetingStatusID { get;set; }
     public Int32? DepartmentID { get;set; }
     public System.String MeetingCancelNotice { get;set; }
     public Department Department { get;set; }
     public MeetingLocation MeetingLocation { get;set; }
     public AMAPI.MeetingStatus MeetingStatu { get;set; }
     public MeetingType MeetingType { get;set; }
}

public class MeetingLocation {
     public Int32? MeetingLocationID { get;set; }
     public System.String MeetingLocationName { get;set; }
     public System.String Address1 { get;set; }
     public System.String Address2 { get;set; }
     public System.String AddressCity { get;set; }
     public System.String AddressState { get;set; }
     public System.String AddressPostal { get;set; }
     public Int16? MediaEncoderID { get;set; }
     public Boolean? Inactive { get;set; }
     public MediaEncoder MediaEncoder { get;set; }
}

public class MeetingSegment {
     public Int32? MeetingSegmentID { get;set; }
     public Int32? MeetingTypeID { get;set; }
     public System.String MeetingSegmentName { get;set; }
     public Boolean? Inactive { get;set; }
     public MeetingType MeetingType { get;set; }
}

public class MeetingType {
     public Int32? MeetingTypeID { get;set; }
     public Int32? MeetingGroupID { get;set; }
     public System.String MeetingTypeName { get;set; }
     public Int32? TemplateSetID { get;set; }
     public System.Byte[] DefaultOutline { get;set; }
     public Boolean? PublicMeeting { get;set; }
     public Boolean? ReviewMeeting { get;set; }
     public Boolean? RecordedMeeting { get;set; }
     public Int32? VotePassBasisID { get;set; }
     public Boolean? Inactive { get;set; }
     public Department MeetingGroup { get;set; }
     public TemplateSet TemplateSet { get;set; }
     public VotePassBasis VotePassBasi { get;set; }
}

public class Minutes {
     public Int32? MinutesID { get;set; }
     public Int32? MeetingID { get;set; }
     public Int32? OutlineFormatID { get;set; }
     public Int32? OpenedUserID { get;set; }
     public DateTime? Opened { get;set; }
     public Int32? MinutesStatusID { get;set; }
     public DateTime? Closed { get;set; }
     public System.String FileFormat { get;set; }
     public System.String FileFormatPublic { get;set; }
     public System.String FileFormatBoard { get;set; }
     public System.String FileFormatStaff { get;set; }
     public DateTime? FileUpdated { get;set; }
     public DateTime? FileUpdatedPublic { get;set; }
     public DateTime? FileUpdatedBoard { get;set; }
     public DateTime? FileUpdatedStaff { get;set; }
     public DateTime? Generated { get;set; }
     public DateTime? Finalized { get;set; }
     public DateTime? WebUpload { get;set; }
     public Int32? WebUploadVersions { get;set; }
     public DateTime? Letters { get;set; }
     public Int32? AcceptMeetingID { get;set; }
     public DateTime? Updated { get;set; }
     public Int32? UpdatedUserID { get;set; }
     public Boolean? AutoLockAddedDocuments { get;set; }
     public Meeting Meeting { get;set; }
     public Meeting AcceptMeeting { get;set; }
     public AMAPI.MinutesStatus MinutesStatu { get;set; }
     public AMAPI.OutlineFormat OutlineFormats { get;set; }
     public UserAccount UpdatedUser { get;set; }
     public UserAccount OpenedUser { get;set; }
     public AMAPI.WebUploadVersions WebUploadVersion { get;set; }
}

public class MinutesItem {
     public Int64? MinutesItemID { get;set; }
     public Int32? MinutesID { get;set; }
     public Int64? ParentItemID { get;set; }
     public Int16? ItemNum { get;set; }
     public Int16? Sort { get;set; }
     public Boolean? DoNotNumber { get;set; }
     public Boolean? ContinuousNumbering { get;set; }
     public Int32? OutlineFormatID { get;set; }
     public DateTime? Start { get;set; }
     public Int32? Duration { get;set; }
     public Int16? PageNum { get;set; }
     public Int16? PageNumAppendix { get;set; }
     public Int16? PageNumPublic { get;set; }
     public Int16? PageNumPublicAppendix { get;set; }
     public Int16? PageNumBoard { get;set; }
     public Int16? PageNumBoardAppendix { get;set; }
     public Int16? PageNumStaff { get;set; }
     public Int16? PageNumStaffAppendix { get;set; }
     public Int32? MinutesItemTypeID { get;set; }
     public Int32? ResolutionID { get;set; }
     public Int32? PublicHearingID { get;set; }
     public Int32? AcceptMinutesID { get;set; }
     public Int32? CommunicationID { get;set; }
     public Int64? AttachmentID { get;set; }
     public Int32? SpeakerSignupID { get;set; }
     public Int16? VoteResultID { get;set; }
     public Int32? NextMeetingID { get;set; }
     public System.String Title { get;set; }
     public Boolean? GUIExpanded { get;set; }
     public System.String FileFormat { get;set; }
     public DateTime? FileUpdated { get;set; }
     public Decimal? MediaPosition { get;set; }
     public Int32? FlagStatusID { get;set; }
     public Int16? TagID { get;set; }
     public Int32? SpeakerSignupPolicyID { get;set; }
     public Boolean? IsSpeakerSignupDefault { get;set; }
     public Attachment Attachment { get;set; }
     public Communication Communication { get;set; }
     public AMAPI.FlagStatus FlagStatu { get;set; }
     public Meeting NextMeeting { get;set; }
     public Minutes Minute { get;set; }
     public Minutes AcceptMinute { get;set; }
     public MinutesItem ParentItem { get;set; }
     public AMAPI.MinutesItemType MinutesItemTypes { get;set; }
     public AMAPI.OutlineFormat OutlineFormats { get;set; }
     public PublicHearing PublicHearing { get;set; }
     public Resolution Resolution { get;set; }
     public SpeakerSignup SpeakerSignup { get;set; }
     public Tag Tag { get;set; }
     public VoteResult VoteResult { get;set; }
}

public class MinutesItemVote {
     public Int64? MinutesItemVoteID { get;set; }
     public Int64? MinutesItemID { get;set; }
     public Int32? UserID { get;set; }
     public Int32? VoteID { get;set; }
     public Int32? VoterRoleID { get;set; }
     public MinutesItem MinutesItem { get;set; }
     public UserAccount User { get;set; }
     public AMAPI.Vote Votes { get;set; }
     public AMAPI.VoterRole VoterRoles { get;set; }
}

public class OrgGroupType {
     public Int16? OrgGroupTypeID { get;set; }
     public System.String OrgGroupTypeName { get;set; }
     public Boolean? Inactive { get;set; }
}

public class Project {
     public Int32? ProjectID { get;set; }
     public System.String ProjectName { get;set; }
     public Int32? ProjectTypeID { get;set; }
     public Int32? DepartmentID { get;set; }
     public Boolean? Inactive { get;set; }
     public Department Department { get;set; }
     public ProjectType ProjectType { get;set; }
}

public class ProjectType {
     public Int32? ProjectTypeID { get;set; }
     public System.String ProjectTypeName { get;set; }
}

public class PublicHearing {
     public Int32? PublicHearingID { get;set; }
     public Int32? OriginResolutionID { get;set; }
     public System.String Title { get;set; }
     public System.String ShortTitle { get;set; }
     public Int32? MeetingID { get;set; }
     public Int32? PublicHearingStatusID { get;set; }
     public Meeting Meeting { get;set; }
     public AMAPI.PublicHearingStatus PublicHearingStatu { get;set; }
     public Resolution OriginResolution { get;set; }
}

public class Recipient {
     public Int32? RecipientID { get;set; }
     public System.String RecipientName { get;set; }
     public Int32? RecipientTypeID { get;set; }
     public Int32? DepartmentID { get;set; }
     public System.String FirstName { get;set; }
     public System.String MiddleName { get;set; }
     public System.String LastName { get;set; }
     public System.String Company { get;set; }
     public System.String Salutation { get;set; }
     public System.String Title { get;set; }
     public System.String Email { get;set; }
     public System.String Address1 { get;set; }
     public System.String Address2 { get;set; }
     public System.String City { get;set; }
     public System.String State { get;set; }
     public System.String Zip { get;set; }
     public System.String Phone { get;set; }
     public System.String Notes { get;set; }
     public Boolean? SignOff { get;set; }
     public Boolean? SendMail { get;set; }
     public Boolean? SendEmail { get;set; }
     public Boolean? Inactive { get;set; }
     public Department Department { get;set; }
     public AMAPI.RecipientType RecipientTypes { get;set; }
}

public class ResLink {
     public Int64? ResLinkID { get;set; }
     public Int32? ResolutionID { get;set; }
     public Int32? ToResolutionID { get;set; }
     public Int32? ResLinkTypeID { get;set; }
     public System.String Memo { get;set; }
     public AMAPI.ResLinkType ResLinkTypes { get;set; }
     public Resolution Resolution { get;set; }
     public Resolution ToResolution { get;set; }
}

public class ResLog {
     public Int64? ResLogID { get;set; }
     public Int32? ResolutionID { get;set; }
     public Int64? AttachmentID { get;set; }
     public DateTime? Created { get;set; }
     public Int32? ResolutionSaveReasonID { get;set; }
     public System.String Comment { get;set; }
     public Int32? UserID { get;set; }
     public Attachment Attachment { get;set; }
     public Resolution Resolution { get;set; }
     public ResolutionSaveReason ResolutionSaveReason { get;set; }
     public UserAccount User { get;set; }
}

public class Resolution {
     public Int32? ResolutionID { get;set; }
     public Int16? LegiFileTypeID { get;set; }
     public System.String Title { get;set; }
     public System.String ShortTitle { get;set; }
     public Int32? MeetingGroupID { get;set; }
     public Int32? MeetingID { get;set; }
     public Int32? DepartmentID { get;set; }
     public Int32? ResolutionCategoryID { get;set; }
     public Int32? InitiatorUserID { get;set; }
     public Int32? PreparerUserID { get;set; }
     public System.String UserText1 { get;set; }
     public System.String UserText2 { get;set; }
     public Int16? UserLookup1 { get;set; }
     public Int16? UserLookup2 { get;set; }
     public Int16? UserLookup3 { get;set; }
     public Int16? UserLookup4 { get;set; }
     public DateTime? UserDate1 { get;set; }
     public DateTime? UserDate2 { get;set; }
     public Int32? UserUser1 { get;set; }
     public Int32? UserUser2 { get;set; }
     public Int32? UserDept1 { get;set; }
     public Int32? UserDept2 { get;set; }
     public System.String FileFormat { get;set; }
     public DateTime? FileUpdated { get;set; }
     public System.String FileFormatDiscussion { get;set; }
     public DateTime? FileUpdatedDiscussion { get;set; }
     public System.String FileFormatComments { get;set; }
     public DateTime? FileUpdatedComments { get;set; }
     public Boolean? TrackChanges { get;set; }
     public DateTime? Submitted { get;set; }
     public DateTime? Adopted { get;set; }
     public DateTime? Abandoned { get;set; }
     public Int16? RevisionNum { get;set; }
     public DateTime? ResolutionNumDate { get;set; }
     public System.String ResolutionNumFormatted { get;set; }
     public System.String FinImpDescription { get;set; }
     public Boolean? FinImpAffectsBudget { get;set; }
     public Int64? ResolutionNum { get;set; }
     public Int32? ResolutionStatusID { get;set; }
     public Boolean? Confidential { get;set; }
     public DateTime? Locked { get;set; }
     public Int32? LockedUserID { get;set; }
     public Int32? VotePassBasisID { get;set; }
     public DateTime? Created { get;set; }
     public DateTime? Updated { get;set; }
     public Int32? UpdatedUserID { get;set; }
     public DateTime? ClerkLocked { get;set; }
     public Int32? ClerkLockedUserID { get;set; }
     public Int32? ClerkLockedMeetingID { get;set; }
     public Boolean? SuperLocked { get;set; }
     public Int32? ExternalKeyID { get;set; }
     public Int16? UserMultiSelect1 { get;set; }
     public Int16? UserMultiSelect2 { get;set; }
     public Int16? UserMultiSelect3 { get;set; }
     public Int16? UserMultiSelect4 { get;set; }
     public Department Department { get;set; }
     public Department MeetingGroup { get;set; }
     public List<Department> UserDept1s { get;set; }
     public List<Department> UserDept2s { get;set; }
     public List<ExternalKey> ExternalKeies { get;set; }
     public LegiFileType LegiFileType { get;set; }
     public List<LegiLookup> UserLookup1s { get;set; }
     public List<LegiLookup> UserLookup2s { get;set; }
     public List<LegiLookup> UserLookup3s { get;set; }
     public List<LegiLookup> UserLookup4s { get;set; }
     public List<LegiLookup> UserMultiSelect1s { get;set; }
     public List<LegiLookup> UserMultiSelect2s { get;set; }
     public List<LegiLookup> UserMultiSelect3s { get;set; }
     public List<LegiLookup> UserMultiSelect4s { get;set; }
     public Meeting ClerkLockedMeeting { get;set; }
     public Meeting Meeting { get;set; }
     public List<ResolutionCategory> ResolutionCategories { get;set; }
     public AMAPI.ResolutionStatus ResolutionStatu { get;set; }
     public UserAccount ClerkLockedUser { get;set; }
     public UserAccount InitiatorUser { get;set; }
     public UserAccount LockedUser { get;set; }
     public UserAccount PreparerUser { get;set; }
     public UserAccount UpdatedUser { get;set; }
     public List<UserAccount> UserUser1s { get;set; }
     public List<UserAccount> UserUser2s { get;set; }
     public VotePassBasis VotePassBasi { get;set; }
}

public class ResolutionApproval {
     public Int64? ResolutionApprovalID { get;set; }
     public Int32? ResolutionID { get;set; }
     public Int64? AttachmentID { get;set; }
     public Int32? StageNum { get;set; }
     public Int32? WorkItemTypeID { get;set; }
     public System.String Description { get;set; }
     public System.String Instructions { get;set; }
     public Int32? DepartmentID { get;set; }
     public Int32? UserID { get;set; }
     public DateTime? DueDate { get;set; }
     public Int32? MeetingID { get;set; }
     public Boolean? MeetingFixed { get;set; }
     public Int32? MeetingSegmentID { get;set; }
     public Int32? OriginWorkItemID { get;set; }
     public Boolean? OriginTargetMeeting { get;set; }
     public Int32? OriginCategoryID { get;set; }
     public Int32? OriginDepartmentID { get;set; }
     public Int64? OriginMinutesItemID { get;set; }
     public Int32? ResolutionApprovalStatusID { get;set; }
     public DateTime? Updated { get;set; }
     public Int32? UpdatedUserID { get;set; }
     public DateTime? StatusUpdated { get;set; }
     public Int32? StatusUpdatedUserID { get;set; }
     public Int64? StatusUpdatedConnectionID { get;set; }
     public System.String Comment { get;set; }
     public Attachment Attachment { get;set; }
     public Department Department { get;set; }
     public Department OriginDepartment { get;set; }
     public Meeting Meeting { get;set; }
     public MeetingSegment MeetingSegment { get;set; }
     public MinutesItem OriginMinutesItem { get;set; }
     public Resolution Resolution { get;set; }
     public AMAPI.ResolutionApprovalStatus ResolutionApprovalStatu { get;set; }
     public List<ResolutionCategory> OriginCategories { get;set; }
     public UserAccount User { get;set; }
     public UserAccount UpdatedUser { get;set; }
     public AMAPI.WorkItemType WorkItemTypes { get;set; }
}

public class ResolutionBudgetLine {
     public Int64? ResolutionBudgetLineID { get;set; }
     public Int32? ResolutionID { get;set; }
     public Int16? LineNum { get;set; }
     public Int32? BudgetSourceID { get;set; }
     public System.String Memo { get;set; }
     public Decimal? Amount { get;set; }
     public DateTime? Timing { get;set; }
     public BudgetSource BudgetSource { get;set; }
     public Resolution Resolution { get;set; }
}

public class ResolutionCategory {
     public Int32? ResolutionCategoryID { get;set; }
     public System.String ResolutionCategoryName { get;set; }
     public Boolean? VisibleAllFileTypes { get;set; }
     public Boolean? VisibleAllDepartments { get;set; }
     public Int32? LetterDistributionListID { get;set; }
     public Boolean? CreatePublicHearing { get;set; }
     public Int32? LegalNoticeTypeID { get;set; }
     public Int32? FunctionalCategoryID { get;set; }
     public Boolean? RequireFinImp { get;set; }
     public Int32? VotePassBasisID { get;set; }
     public Boolean? Inactive { get;set; }
     public DistributionList LetterDistributionList { get;set; }
     public List<FunctionalCategory> FunctionalCategories { get;set; }
     public LegalNoticeType LegalNoticeType { get;set; }
     public VotePassBasis VotePassBasi { get;set; }
}

public class ResolutionSaveReason {
     public Int32? ResolutionSaveReasonID { get;set; }
     public System.String ResolutionSaveReasonName { get;set; }
     public Boolean? ResetApprovals { get;set; }
     public Boolean? IncrementRevision { get;set; }
     public Boolean? SendEmail { get;set; }
     public System.String DefaultText { get;set; }
     public Boolean? Inactive { get;set; }
}

public class SpeakerSignup {
     public Int32? SpeakerSignupID { get;set; }
     public Int32? MeetingID { get;set; }
     public System.String Name { get;set; }
     public Int32? UserID { get;set; }
     public System.String Phone { get;set; }
     public System.String Address { get;set; }
     public System.String Comment { get;set; }
     public DateTime? Created { get;set; }
     public System.String Email { get;set; }
     public Meeting Meeting { get;set; }
     public UserAccount User { get;set; }
}

public class SpeakerSignupItem {
     public Int32? SpeakerSignupItemID { get;set; }
     public Int32? SpeakerSignupID { get;set; }
     public Int64? AgendaItemID { get;set; }
     public Int64? MinutesItemID { get;set; }
     public System.String ItemComments { get;set; }
     public Boolean? SpeakerApproves { get;set; }
     public Boolean? AutoFillAgenda { get;set; }
     public Boolean? AutoFillMinutes { get;set; }
     public Int16? AgendaSort { get;set; }
     public Int16? MinutesSort { get;set; }
     public Decimal? MediaPosition { get;set; }
     public System.String FileFormatAgendaComments { get;set; }
     public DateTime? FileUpdatedAgendaComments { get;set; }
     public System.String FileFormatMinutesComments { get;set; }
     public DateTime? FileUpdatedMinutesComments { get;set; }
     public DateTime? StartTime { get;set; }
     public Int32? Duration { get;set; }
     public AgendaItem AgendaItem { get;set; }
     public MinutesItem MinutesItem { get;set; }
     public SpeakerSignup SpeakerSignup { get;set; }
}

public class Tag {
     public Int16? TagID { get;set; }
     public System.String TagName { get;set; }
     public System.String Description { get;set; }
     public Boolean? Inactive { get;set; }
}

public class Task {
     public Int32? TaskID { get;set; }
     public System.String Subject { get;set; }
     public Int32? TaskStatusID { get;set; }
     public Int32? TaskPriorityID { get;set; }
     public Int32? PercentCompleted { get;set; }
     public DateTime? DueDate { get;set; }
     public DateTime? StartDate { get;set; }
     public DateTime? CompletionDate { get;set; }
     public DateTime? ReminderDate { get;set; }
     public Int32? EstimatedWork { get;set; }
     public Int32? ActualWork { get;set; }
     public Int32? ResolutionID { get;set; }
     public System.String Summary { get;set; }
     public System.String FileFormat { get;set; }
     public DateTime? FileUpdated { get;set; }
     public DateTime? Created { get;set; }
     public Int32? CreatedUserID { get;set; }
     public DateTime? Updated { get;set; }
     public Int32? UpdatedUserID { get;set; }
     public Resolution Resolution { get;set; }
     public AMAPI.TaskPriority TaskPriorities { get;set; }
     public TaskStatus TaskStatu { get;set; }
     public UserAccount CreatedUser { get;set; }
     public UserAccount UpdatedUser { get;set; }
}

public class Template {
     public Int32? TemplateID { get;set; }
     public Int32? TemplateTypeID { get;set; }
     public System.String TemplateName { get;set; }
     public System.String FileFormat { get;set; }
     public DateTime? FileUpdated { get;set; }
     public Int16? LegiFileTypeID { get;set; }
     public Int32? DepartmentID { get;set; }
     public System.String Description { get;set; }
     public DateTime? Created { get;set; }
     public DateTime? Updated { get;set; }
     public Boolean? PredefinedTemplate { get;set; }
     public Boolean? Inactive { get;set; }
     public Department Department { get;set; }
     public LegiFileType LegiFileType { get;set; }
     public AMAPI.TemplateType TemplateTypes { get;set; }
}

public class TemplateSet {
     public Int32? TemplateSetID { get;set; }
     public System.String TemplateSetName { get;set; }
     public Int32? MeetingGroupID { get;set; }
     public Boolean? Predefined { get;set; }
     public Boolean? Inactive { get;set; }
     public Department MeetingGroup { get;set; }
}

public class UserAccount {
     public Int32? UserID { get;set; }
     public Int32? UserTypeID { get;set; }
     public System.String UserName { get;set; }
     public System.String UserLogin { get;set; }
     public System.String Password { get;set; }
     public System.String Salutation { get;set; }
     public System.String FirstName { get;set; }
     public System.String MiddleName { get;set; }
     public System.String LastName { get;set; }
     public DateTime? BirthDate { get;set; }
     public Int32? GenderID { get;set; }
     public Int32? EthnicityID { get;set; }
     public System.String Title { get;set; }
     public System.String Email { get;set; }
     public System.String Phone { get;set; }
     public System.String PublicEmail { get;set; }
     public System.String PublicPhone { get;set; }
     public System.String Biography { get;set; }
     public Int32? PortraitCFID { get;set; }
     public Int32? SignatureCFID { get;set; }
     public Int32? RecipientID { get;set; }
     public Boolean? RecipientAutoUpdate { get;set; }
     public Int32? MeetingGroupID { get;set; }
     public Boolean? NoApprovals { get;set; }
     public Boolean? NoEmailNotices { get;set; }
     public Boolean? NoEmailDashboard { get;set; }
     public Boolean? Sponsor { get;set; }
     public Int32? Clerk { get;set; }
     public Int32? ClerkPermissions { get;set; }
     public Boolean? Admin { get;set; }
     public Boolean? Manager { get;set; }
     public Boolean? MediaManager { get;set; }
     public Boolean? Disabled { get;set; }
     public Int32? SecurityLockOutID { get;set; }
     public Boolean? ChangePW { get;set; }
     public Int32? FailedLogins { get;set; }
     public DateTime? Expires { get;set; }
     public DateTime? LastPWChange { get;set; }
     public System.String PreviousPasswords { get;set; }
     public System.String RefText1 { get;set; }
     public System.String RefText2 { get;set; }
     public System.String RefText3 { get;set; }
     public System.String RefText4 { get;set; }
     public System.String RefText5 { get;set; }
     public DateTime? Updated { get;set; }
     public Int32? UpdatedUserID { get;set; }
     public Boolean? Inactive { get;set; }
     public DateTime? Created { get;set; }
     public ContentFile PortraitCF { get;set; }
     public ContentFile SignatureCF { get;set; }
     public Department MeetingGroup { get;set; }
     public AMAPI.Ethnicity Ethnicities { get;set; }
     public AMAPI.Gender Genders { get;set; }
     public Recipient Recipient { get;set; }
     public AMAPI.SecurityLockOut SecurityLockOuts { get;set; }
     public AMAPI.UserType UserTypes { get;set; }
}

public class VotePassBasis {
     public Int32? VotePassBasisID { get;set; }
     public System.String Name { get;set; }
     public Boolean? CountPresentOnly { get;set; }
     public Decimal? PassPercent { get;set; }
}

public class VoteResult {
     public Int16? VoteResultID { get;set; }
     public Int32? MinutesItemTypeID { get;set; }
     public Int16? LegiFileTypeID { get;set; }
     public System.String VoteResultName { get;set; }
     public System.String MotionName { get;set; }
     public Int32? VoteResultRoutingID { get;set; }
     public Boolean? RequireVoteInfo { get;set; }
     public Boolean? Successful { get;set; }
     public Boolean? Cancelled { get;set; }
     public Boolean? AssignNumber { get;set; }
     public Boolean? ControllingGroupOnly { get;set; }
     public Int32? StatusUpdate { get;set; }
     public Int32? Sort { get;set; }
     public Boolean? DefaultResult { get;set; }
     public Boolean? Inactive { get;set; }
     public AMAPI.VoteResultRouting VoteResultRoutings { get;set; }
}


}
