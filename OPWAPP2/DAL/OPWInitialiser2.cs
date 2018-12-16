using OPWAPP2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace OPWAPP2.DAL
{
    public class OPWInitialiser2 : DropCreateDatabaseIfModelChanges<OPWContext2>
    {
        protected override void Seed(OPWContext2 context)
        {
            var authorisation = new List<Authorisation>
                    
            {
            new Authorisation{User_Name = "Jeff Holding", User_Password = "12345678", Company = User_Company.OPW, Usersect = User_Section.Elective_Works,Usersectcode=User_Section_Code.E30_ZS_34 ,Email="jholding@opw.com",approvalStatus = ApprovalStatus.Approved,User_Approval_Limit=0},
            new Authorisation{User_Name = "Tim Allen", User_Password = "12345678", Company = User_Company.OPW, Usersect = User_Section.MandE_Works,Usersectcode=User_Section_Code.k00_ZS_34,Email="tallen@opw.com",approvalStatus = ApprovalStatus.Approved,User_Approval_Limit=0},
            new Authorisation{User_Name = "Mick Byrne", User_Password = "12345678", Company = User_Company.OPW, Usersect = User_Section.Capital_works,Usersectcode=User_Section_Code.J10_ZS_34,Email="pcolemen@opw.com",approvalStatus = ApprovalStatus.Approved,User_Approval_Limit=0 },
            new Authorisation{User_Name = "Paul Colemen", User_Password = "12345678", Company = User_Company.OPW, Usersect = User_Section.Storage,Usersectcode=User_Section_Code.L00_ZH_34,Email="pcolemen@opw.com",approvalStatus = ApprovalStatus.Approved,User_Approval_Limit=0 },
            new Authorisation{User_Name = "Finbarr Cullen", User_Password = "12345678", Company = User_Company.DEASP, Usersect = User_Section.Accommodation,Usersectcode=User_Section_Code.FMU1,Email="dcullen@opw.com",approvalStatus = ApprovalStatus.Approved,User_Approval_Limit=50000},
            new Authorisation{User_Name = "Sinead Murphy", User_Password = "12345678", Company = User_Company.DEASP, Usersect = User_Section.Finance ,Usersectcode=User_Section_Code.FMU2,Email="smurphy@opw.com",approvalStatus = ApprovalStatus.Approved,User_Approval_Limit=0},
            new Authorisation{User_Name = "John Lee", User_Password = "12345678", Company = User_Company.DEASP, Usersect = User_Section.Admin ,Usersectcode=User_Section_Code.Admin,Email="jlee@opw.com",approvalStatus = ApprovalStatus.Approved,User_Approval_Limit=999999999},
            new Authorisation{User_Name = "Colm Carberry", User_Password = "12345678", Company = User_Company.DEASP, Usersect = User_Section.Admin, Usersectcode=User_Section_Code.Admin,Email="ccarberry@opw.com",approvalStatus = ApprovalStatus.Approved,User_Approval_Limit=0999999999}
            };
            authorisation.ForEach(s => context.Opwauthorisation2.Add(s));
            context.SaveChanges();
            /* (CJC)
              
             try
            {
                authorisation.ForEach(s => context.Opwauthorisation2.Add(s));
                context.SaveChanges();
            }

            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                        Console.ReadLine();
                    }
                }
                throw;
            }

        */

            // Property test data
            var property = new List<Property>
            {
new Property{OPW_Building_Code="B0591",Address="Carlow Intreo Centre(1), Kennedy Avenue, Carlow, Co. Carlow", County="Co. Carlow",Type = Property_Type.DEASP, Cost_Centre="V3150",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8577",Address="Carlow Intreo Centre(2), Hanover House, Hanover Road, Carlow, Co. Carlow", County="Co. Carlow",Type = Property_Type.DEASP, Cost_Centre="V4718",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8691",Address="Birr SWO, Birr Technology Centre, St Brendan's Street, Birr, Co Offaly", County="Co Offaly",Type = Property_Type.DEASP, Cost_Centre="V4201",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B0034",Address="Áras Mhic Dhiarmada, HQ Building, Store Street, Dublin 1", County="Dublin 1",Type = Property_Type.DEASP, Cost_Centre="V4000",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B0052",Address="Ardee Social Welfare Office, Fairgreen, Civic Offices Ardee Court House, Ardee, Co. Louth", County="Co. Louth",Type = Property_Type.DEASP, Cost_Centre="V4111",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B0135",Address="Bailieborough Social Welfare Office, Barrack Street, Baileborough, Co. Cavan", County="Co. Cavan",Type = Property_Type.DEASP, Cost_Centre="V4102",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B0152",Address="Ballina Intreo Centre, Government Buildings, Ballina, Co. Mayo", County="Co. Mayo",Type = Property_Type.DEASP, Cost_Centre="V3050",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B0165",Address="Ballinasloe Social Welfare Office, The Old Bank Chambers, 3 Society Street, Ballinasloe, Co. Galway", County="Co. Galway",Type = Property_Type.DEASP, Cost_Centre="V4177",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B0223",Address="Ballybofey Social Welfare Office, Units 14/15, Shopping Centre, Chestnut Road, Ballybofey, Co. Donegal ", County="Co. Donegal",Type = Property_Type.DEASP, Cost_Centre="V4140",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B0251",Address="Ballyfermot Intreo Centre, Rossmore Avenue, Ballyfermot, Dublin 10", County="Dublin 10",Type = Property_Type.DEASP, Cost_Centre="V3340",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B0315",Address="Ballyshannon Social Welfare Office, Belleek Road, Ballyshannon, Co. Donegal", County="Co. Donegal",Type = Property_Type.DEASP, Cost_Centre="V4132",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B0349",Address="Bantry Social Welfare Office, 7 Main Street, Bantry, Co. Cork", County="Co. Cork",Type = Property_Type.DEASP, Cost_Centre="V4112",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B0381",Address="Belmullet Intreo Centre, American Street, Belmullet, Co. Mayo", County="Co. Mayo",Type = Property_Type.DEASP, Cost_Centre="V3110",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B0544",Address="Navan Road Intreo Centre, Navan Road, Cabra, Dublin 7", County="Dublin 7",Type = Property_Type.DEASP, Cost_Centre="V3415",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B0552",Address="Cahirciveen Intreo Centre, St. Brendan's Terrace, Cahirciveen, Co. Kerry", County="Co. Kerry",Type = Property_Type.DEASP, Cost_Centre="V3140",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B0593",Address="Carlow Social Welfare Office, Strawhall Industrial Estate, Athy Road, Co. Carlow", County="Co. Carlow",Type = Property_Type.DEASP, Cost_Centre="V4078",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B0620",Address="Carrick on Shannon Intreo Centre, Leitrim House, Leitrim Road, Carrick on Shannon, Co. Leitrim", County="Co. Leitrim",Type = Property_Type.DEASP, Cost_Centre="V3170",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B0662",Address="Castlebar Intreo Centre, Michael Davitt House, Castlebar, Co. Mayo ", County="Co. Mayo",Type = Property_Type.DEASP, Cost_Centre="V3180",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B0671",Address="Castleblaney Social Welfare Office, Monaghan Road, Castleblaney, Co. Monaghan", County="Co. Monaghan",Type = Property_Type.DEASP, Cost_Centre="V4352",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B0702",Address="Castletownbere Social Welfare Office, Church Gate, Castletownbere, Co. Cork", County="Co. Cork",Type = Property_Type.DEASP, Cost_Centre="V3086",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B0714",Address="Cavan Intreo Centre, Dublin Road, Cavan, Co. Cavan", County="Co. Cavan",Type = Property_Type.DEASP, Cost_Centre="V3190",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B0731",Address="Donegal Public Service Centre, Drumlonagher, Donegal, Co. Donegal", County="Co. Donegal",Type = Property_Type.DEASP, Cost_Centre="V3635",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B0794",Address="Clonakilty Social Welfare Office, 9 Wolfe Tone Way, Clonakilty, Co. Cork", County="Co. Cork",Type = Property_Type.DEASP, Cost_Centre="V4125",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B0804",Address="Clones Social Welfare Office, Fitzpatrick Square, Clones, Co. Monaghan", County="Co. Monaghan",Type = Property_Type.DEASP, Cost_Centre="V4248",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B0835",Address="Cobh Intreo Centre, 1 Lynch's Quay, Cobh, Co. Cork", County="Co. Cork",Type = Property_Type.DEASP, Cost_Centre="V3240",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B0857",Address="Kilmainham West, Con Colbert House, Computer Centre HQ, 72-100 Inchicore Road, Kilmainham, Dublin 7", County="Dublin 7",Type = Property_Type.DEASP, Cost_Centre="V4033",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B0858",Address="Kilmainham East, Con Colbert House, Computer Centre HQ, 72-100 Inchicore Road, Kilmainham, Dublin 8 ", County="Dublin 8 ",Type = Property_Type.DEASP, Cost_Centre="V4034",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B0894",Address="Cork Intreo Centre, Hanover Street, Cork, Co. Cork", County="Co. Cork",Type = Property_Type.DEASP, Cost_Centre="V3260",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B0994",Address="D'Olier House, Appeals Office & PSC Centre, D'Olier Street, Dublin 2", County="Dublin 2",Type = Property_Type.DEASP, Cost_Centre="V4010",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B1063",Address="Portlaoise Employment Services Office, JFL House, James Fintan Lawlor Avenue, Portlaoise, Co. Laois", County="Co. Laois",Type = Property_Type.DEASP, Cost_Centre="V4715",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B1127",Address="Drogheda Intreo Centre, Maritime House, Custom House Quay, Mayoralty Street, Drogheda, Co. Louth", County="Co. Louth",Type = Property_Type.DEASP, Cost_Centre="V3305",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B1160",Address="Monaghan Public Service Card Centre, Unit 1/3/4 & Basement, Teach O'Cleircin, Old Cross Square, Monaghan, Co. Monaghan", County="Co. Monaghan",Type = Property_Type.DEASP, Cost_Centre="V4048",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B1194",Address="Dunfanaghy Intreo Centre, Main Street, Dunfanaghy, Co. Donegal", County="Co. Donegal",Type = Property_Type.DEASP, Cost_Centre="V3530",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B1209",Address="Dunmanway Social Welfare Office, Church Street, Dunmanway, Co. Cork", County="Co. Cork",Type = Property_Type.DEASP, Cost_Centre="V4116",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B1316",Address="Finglas Intreo Centre, Mellowes Road, Finglas, Dublin 11  ", County="Dublin 11  ",Type = Property_Type.DEASP, Cost_Centre="V3350",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B1891",Address="Goldsmith House HQ,  7-13 Pearse Street, Dublin 2", County="Dublin 2",Type = Property_Type.DEASP, Cost_Centre="V4025",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B1897",Address="Gorey Social Welfare Office, Thomas Street, Gorey, Co. Wexford (Leased from SWBO)", County="Co. Wexford",Type = Property_Type.DEASP, Cost_Centre="V4294",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B1912",Address="Granard Social Welfare Office, 1 Moxham Street, Granard, Co. Longford", County="Co. Longford",Type = Property_Type.DEASP, Cost_Centre="V4218",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B1942",Address="Kilbarrack Intreo Centre, Greendale Shopping Centre, Greendale Road, Kilbarrack, Dublin 5 ", County="Dublin 5 ",Type = Property_Type.DEASP, Cost_Centre="V3410",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B2095",Address="Kells Social Welfare Office, Headfort Place, John Street, Kells, Co. Meath", County="Co. Meath",Type = Property_Type.DEASP, Cost_Centre="V4242",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B2100",Address="Kenmare Intreo Centre, Bridge Street, Kenmare, Co. Kerry", County="Co. Kerry",Type = Property_Type.DEASP, Cost_Centre="V3095",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B2249",Address="Kilrush Social Welfare Office, 45 Moore Street, Kilrush, Co. Clare", County="Co. Clare",Type = Property_Type.DEASP, Cost_Centre="V4108",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B2356",Address="Letterkenny Intreo Centre, High Road, Letterkenny, Co. Donegal", County="Co. Donegal",Type = Property_Type.DEASP, Cost_Centre="V3640",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B2370",Address="Killybegs Social Welfare Office, Unit 3 & 4, Donegal Road, Killybegs, Co. Donegal", County="Co. Donegal",Type = Property_Type.DEASP, Cost_Centre="V4142",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B2388",Address="Limerick Intreo Centre, Dominic Street, Limerick, Co. Limerick", County="Co. Limerick",Type = Property_Type.DEASP, Cost_Centre="V3665",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B2434",Address="Lismore Intreo, West Street, Lismore, Co. Waterford", County="Co. Waterford",Type = Property_Type.DEASP, Cost_Centre="V4038",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B2460",Address="Longford Government Buildings, Ballinalee Road, Longford, Co. Longford", County="Co. Longford",Type = Property_Type.DEASP, Cost_Centre="V4054",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B2650",Address="Mullingar Intreo Centre, Blackhall Street, Mullingar, Co. Westmeath", County="Co. Westmeath",Type = Property_Type.DEASP, Cost_Centre="V3745",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B2651",Address="Mullingar Intreo Centre, Bellview, Dublin Road, Mullingar, Co. Westmeath", County="Co. Westmeath",Type = Property_Type.DEASP, Cost_Centre="V4221",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B2679",Address="Naas Department of Social Protection Office, Unit 2, Rathasker Square, Naas, Co. Kildare", County="Co. Kildare",Type = Property_Type.DEASP, Cost_Centre="V4196",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B2712",Address="Nenagh Social Welfare Office, Government Buildings, St. Conlon's Road, Nenegh, Co. Tipperary", County="Co. Tipperary",Type = Property_Type.DEASP, Cost_Centre="V4272",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B2727",Address="New Ross Social Welfare Office, (Former Garda Station), Cross Street, New Ross, Co. Wexford", County="Co. Wexford",Type = Property_Type.DEASP, Cost_Centre="V4296",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B2738",Address="NewcastleWest Intreo Centre, Newcastlewest Government Buildings, Gortboy, Newcastlewest, Co. Limerick", County="Co. Limerick",Type = Property_Type.DEASP, Cost_Centre="V3775",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B2762",Address="Nutgrove Intreo Centre, Nutgrove Shopping Centre, Rathfarnham, Dublin 14", County="Dublin 14",Type = Property_Type.DEASP, Cost_Centre="V3425",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B3380",Address="Sligo Intreo Centre, Government Offices, Cranmore Road, Sligo, Co. Sligo", County="Co. Sligo",Type = Property_Type.DEASP, Cost_Centre="V3785",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B3382",Address="Sligo Pensions Services Office, College Road, Sligo, Co. Sligo", County="Co. Sligo",Type = Property_Type.DEASP, Cost_Centre="V4045",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B3717",Address="Tallaght Intreo Centre, Social Services Centre, The Square, Tallaght, Dublin 24", County="Dublin 24",Type = Property_Type.DEASP, Cost_Centre="V3435",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B3719",Address="Tallaght Public Service Card Centre, The Square, Unit 247, Level 2, Belgard Square East, Tallaght, Dublin 24", County="Dublin 24",Type = Property_Type.DEASP, Cost_Centre="V4793",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B3767",Address="Thurles Intreo Centre, Tipperary Technology Park, Racecourse Road, Thurles, Co. Tipperary", County="Co. Tipperary",Type = Property_Type.DEASP, Cost_Centre="V4037",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B3808",Address="Tralee Intreo Centre, Government Buildings, Godfrey Place, Tralee, Co. Kerry", County="Co. Kerry",Type = Property_Type.DEASP, Cost_Centre="V3820",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B3891",Address="Westport Intreo Centre, James Street, Westport, Co. Mayo", County="Co. Mayo",Type = Property_Type.DEASP, Cost_Centre="V4799",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B3937",Address="Dun Laoghaire Intreo Centre, 18-21 Cumberland Street, Dun Laoghaire, Co. Dublin ", County="Co. Dublin",Type = Property_Type.DEASP, Cost_Centre="V3375",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B3945",Address="Bandon Social Welfare Office, Unit 1, Weir Street, Bandon, Co. Cork ", County="Co. Cork",Type = Property_Type.DEASP, Cost_Centre="V4110",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B3951",Address="Letterkenny Intreo Centre & CTBO, St. Oliver Plunkett Road, Letterkenny, Co. Donegal", County="Co. Donegal",Type = Property_Type.DEASP, Cost_Centre="V4050",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B3953",Address="Ballymun Intreo Centre, Main Street, Ballymun, Dublin 9", County="Dublin 9",Type = Property_Type.DEASP, Cost_Centre="V3345",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B3960",Address="Cork MRA, Connolly Hall, Lapp's Quay, Cork, Co. Cork", County="Co. Cork",Type = Property_Type.DEASP, Cost_Centre="V4303",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B3979",Address="Cliften Intreo Centre, Galway Road, Clifden, Co. Galway", County="Co. Galway",Type = Property_Type.DEASP, Cost_Centre="V3205",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B3989",Address="Achill Intreo Centre, Achill Sound, Achill, Co. Mayo", County="Co. Mayo",Type = Property_Type.DEASP, Cost_Centre="V3000",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B4005",Address="Elizabeth O'Farrell House, 19-28 North Cumberland Street, Dublin 1,", County="Dublin 1,",Type = Property_Type.DEASP, Cost_Centre="V3365",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B4009",Address="Gandon House, HQ Building, Amiens Street, Dublin 1", County="Dublin 1",Type = Property_Type.DEASP, Cost_Centre="V4015",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B4162",Address="Werburgh street General Registry Office, Hoey's Court, Werburgh Street, Dublin 8 ", County="Dublin 8 ",Type = Property_Type.DEASP, Cost_Centre="V4105",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B4176",Address="Santry Stores, Shanowen Road, Santry, Dublin 9", County="Dublin 9",Type = Property_Type.DEASP, Cost_Centre="V4041",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B4363",Address="Ballinamore Social Welfare Office, High Street, Ballinamore, Co. Leitrim", County="Co. Leitrim",Type = Property_Type.DEASP, Cost_Centre="V4206",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B4476",Address="Bantry Control Office, 6 Main Street, Bantry, Co. Cork", County="Co. Cork",Type = Property_Type.DEASP, Cost_Centre="V3075",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B4596",Address="Manorhamiliton Intreo Centre, Sligo Road, Manorhamilton, Co. Leitrim ", County="Co. Leitrim ",Type = Property_Type.DEASP, Cost_Centre="V3735",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B4673",Address="Carndonagh Public Services Centre, Malin Road, Carndonagh, Co. Donegal", County="Co. Donegal",Type = Property_Type.DEASP, Cost_Centre="V4145",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B4747",Address="Monaghan Social Welfare Office, The Plantation, Government Buildings", County="Co. Monaghan",Type = Property_Type.DEASP, Cost_Centre="V4250",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B5080",Address="Kilkenny Intreo Centre, Government Buildings, Hebron Road, Kilkenny, Co. Kilkenny", County="Co. Kilkenny",Type = Property_Type.DEASP, Cost_Centre="V4076",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B5129",Address="Portlaoise Social Welfare Office, Government Buildings, Abbeyleix Road, Co. Laois", County="Co. Laois",Type = Property_Type.DEASP, Cost_Centre="V4204",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B5131",Address="Ennis Intreo Centre, Block 1, Govt. Buildings, Kilrush Road, Ennis, Co. Clare", County="Co. Clare",Type = Property_Type.DEASP, Cost_Centre="V3550",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B5132",Address="Ennis Intreo Centre, Block 2, Govt. Buildings, Kilrush Road, Ennis, Co. Clare", County="Co. Clare",Type = Property_Type.DEASP, Cost_Centre="V3551",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B5183",Address="Waterford Intreo Centre/ Regional Headquarters, Government Buildings, Cork Road, Waterford, Co. Waterford", County="Co. Waterford",Type = Property_Type.DEASP, Cost_Centre="V4056",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B6199",Address="Carrick-on-Suir CWS, Zone 3, 55 New Street, Carrick-on-Suir, Co Tipperary (Storage)", County="Co. Tipperary",Type = Property_Type.DEASP, Cost_Centre="V4541",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B6206",Address="Clondalkin Intreo Centre, Ninth Locke Road, Clondalkin, Dublin 22", County="Dublin 22",Type = Property_Type.DEASP, Cost_Centre="V3355",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B6207",Address="Clonmel Intreo Centre, Harbour House, New Quay, Clonmel, Co. Tipperary", County="Co. Tipperary",Type = Property_Type.DEASP, Cost_Centre="V3215",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B6239",Address="Dungarvan Social Welfare Office, Civic Offices, Davitt's Quay, Co. Waterford", County="Co. Waterford",Type = Property_Type.DEASP, Cost_Centre="V4289",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B6295",Address="Tallaght Department of Social Protection (St. John's House), High Street, Tallaght, Dublin 24", County="Dublin 24",Type = Property_Type.DEASP, Cost_Centre="V4157",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B7702",Address="Blanchardstown Intreo Centre, Westend House, Snugborough Road, Blanchardstown, Dublin 15", County="Dublin 15",Type = Property_Type.DEASP, Cost_Centre="V3420",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8013",Address="Fermoy Social Welfare Office, Connolly Street, Fermoy, Co. Cork", County="Co. Cork",Type = Property_Type.DEASP, Cost_Centre="V4118",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8014",Address="Roscrea Social Welfare Office, 1 Old Malt House, Valley Place, Roscrea, Co. Tipperary", County="Co. Tipperary",Type = Property_Type.DEASP, Cost_Centre="V4271",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8044",Address="Wicklow Social Welfare Office, Government Buildings, The Murrough, Wicklow, Co. Wicklow", County="Co. Wicklow",Type = Property_Type.DEASP, Cost_Centre="V4301",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8056",Address="Boyle Social Welfare Office, Elphin Street, Boyle, Co. Roscommon", County="Co. Roscommon",Type = Property_Type.DEASP, Cost_Centre="V4260",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8078",Address="Dundalk Intreo Centre/ Regional Office, Government Buildings, St Alphonsus Road, Dundalk, Co. Louth", County="Co. Louth",Type = Property_Type.DEASP, Cost_Centre="V4421",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8084",Address="Gardiner Street Asylum Seekers Unit/CWS, 77 Upper Gardiner Street, Dublin 1", County="Dublin 1",Type = Property_Type.DEASP, Cost_Centre="V4508",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8090",Address="Wexford Intreo Centre, Government Office 1,  Anne Street, Wexford, Co. Wexford", County="Co. Wexford",Type = Property_Type.DEASP, Cost_Centre="V3885",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8093",Address="Bishop's Square Intreo Centre, Redmonds's Hill, Dublin 2", County="Dublin 2",Type = Property_Type.DEASP, Cost_Centre="V3470",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8104",Address="Moville Social Welfare Office, Greencastle Road, Moville, Co. Donegal", County="Co. Donegal",Type = Property_Type.DEASP, Cost_Centre="V4144",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8140",Address="Parnell Street IT Training, 16-17 Parnell Street, Dublin 1", County="Dublin 1",Type = Property_Type.DEASP, Cost_Centre="V2891",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8143",Address="Navan Intreo Centre, Kennedy House, Kennedy Road, Navan, Co. Meath", County="Co. Meath",Type = Property_Type.DEASP, Cost_Centre="V3310",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8163",Address="Listowel Intreo Centre, The Square, Listowel, Co. Kerry", County="Co. Kerry",Type = Property_Type.DEASP, Cost_Centre="V3695",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8167",Address="Falcarragh Social Welfare Office, Unit 7, Main Street, Falcarragh, Co. Donegal", County="Co. Donegal",Type = Property_Type.DEASP, Cost_Centre="V4130",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8180",Address="Arklow Intreo Centre, Castle Park, Arklow, Co. Wicklow ", County="Co. Wicklow ",Type = Property_Type.DEASP, Cost_Centre="V3010",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8183",Address="Youghal Social Welfare Office, Unit 2, Watson Lane, 14a North Main Street, Youghal, Co. Cork", County="Co. Cork",Type = Property_Type.DEASP, Cost_Centre="V4126",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8189",Address="Kilmallock Social Welfare Office, Charleville Road, Kilmallock, Co. Limerick", County="Co. Limerick",Type = Property_Type.DEASP, Cost_Centre="V4214",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8214",Address="Dungloe, Intreo Centre, Public Service Centre, Gweedore Road, Dungloe, Co. Donegal", County="Co. Donegal",Type = Property_Type.DEASP, Cost_Centre="V3540",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8232",Address="Enniscorthy Social Welfare Office, Portsmouth House, Shannon Quay, Enniscorthy, Co. Wexford", County="Co. Wexford",Type = Property_Type.DEASP, Cost_Centre="V4292",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8296",Address="Bray Intreo Centre, Unit 1, Block 1, The Civic Centre, Main Street, Bray, Co. Wicklow", County="Co. Wicklow",Type = Property_Type.DEASP, Cost_Centre="V3120",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8306",Address="Baltinglass Department of Social Protection Office, Ground Floor, Unit 2, Edward Street, Baltinglass, Co. Wicklow", County="Co. Wicklow",Type = Property_Type.DEASP, Cost_Centre="V4307",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8321",Address="Killarney Intreo Centre, Park Court, Beech Road, Killarney, Co. Kerry", County="Co. Kerry",Type = Property_Type.DEASP, Cost_Centre="V3830",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8322",Address="Carrick on Shannon, Regional Office, Shannon Lodge, Government Offices, Dublin Road, Carrick on Shannon, Co. Leitrim", County="Co. Leitrim",Type = Property_Type.DEASP, Cost_Centre="V4057",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8327",Address="Macroom Social Welfare Office, Bowl Road, Macroom, Co. Cork", County="Co. Cork",Type = Property_Type.DEASP, Cost_Centre="V4120",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8333",Address="Coolock Intreo Centre, Northside Civic Centre, Bunratty Road, Coolock, Dublin 17 ", County="Dublin 17 ",Type = Property_Type.DEASP, Cost_Centre="V3385",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8352",Address="Tullamore Intreo Centre, Unit 1, Castle Buildings, Tara Street, Tullamore, Co. Offaly", County="Co. Offaly",Type = Property_Type.DEASP, Cost_Centre="V3740",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8380",Address="Navan Intreo Centre, Abbey Mall, Abbey Road, Navan, Co. Meath", County="Co. Meath",Type = Property_Type.DEASP, Cost_Centre="V3311",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8389",Address="Parnell Street Intreo Centre, 20 King's Inn Street, Dublin 1", County="Dublin 1",Type = Property_Type.DEASP, Cost_Centre="V3370",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8394",Address="Carrigaline Intreo Centre, Unit 2, The Maltings, Main Street, Carrigaline, Co. Cork", County="Co. Cork",Type = Property_Type.DEASP, Cost_Centre="V3300",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8413",Address="North King Street, 90 North King Street, Smithfield, Dublin 7", County="Dubin 7",Type = Property_Type.DEASP, Cost_Centre="V4039",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8438",Address="Athlone Intreo Centre, Grace Park Road, Athlone, Co. Westmeath", County="Co. Westmeath",Type = Property_Type.DEASP, Cost_Centre="V3020",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8443",Address="Limerick Regional Office, 2nd Floor, Riverstone House, 23-27 Henry Street, Limerick, Co Limerick", County="Co. Limerick",Type = Property_Type.DEASP, Cost_Centre="V4313",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8451",Address="Roscommon Intreo Office/G.R.O. Government Buildings, Convent Road, Roscommon, Co. Roscommon", County="Co.Roscommon",Type = Property_Type.DEASP, Cost_Centre="V4104",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8470",Address="Buncrana Intreo Centre & Headquarters, McCarter's Road, Buncrana, Co. Donegal", County="Co. Donegal",Type = Property_Type.DEASP, Cost_Centre="V4058",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8482",Address="Mallow Social Welfare Local Office, Government Buildings, Unit 5, Fair Green, New Road, Co. Cork ", County="Co. Cork ",Type = Property_Type.DEASP, Cost_Centre="V3288",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8501",Address="Athy Department of Social Protection Office, Unit 4, Floor 2, Stanhope Place, Athy, Co. Kildare", County="Co. Kildare",Type = Property_Type.DEASP, Cost_Centre="V4186",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8510",Address="Burgh Quay, Corn Exchange, Headquarters/SIU, Unit A ,Burgh Quay,Dublin 2", County="Dublin 2",Type = Property_Type.DEASP, Cost_Centre="V4507",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8512",Address="Damastown CWS, Damestown Close,Damastown Industrial Estate, Mulhuddard,Dublin 15", County="Dublin 15",Type = Property_Type.DEASP, Cost_Centre="V4511",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8519",Address="Dundalk CWS, Unit 2, Adelphi Court, Dundalk, Co. Louth", County="Co. Louth",Type = Property_Type.DEASP, Cost_Centre="V4526",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8520",Address="Ballymahon CWS, Unit 4, Parkside Business Centre, Co Longford", County="Co. Longford",Type = Property_Type.DEASP, Cost_Centre="V4519",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8524",Address="Dungarvan CWS, 1A Mitchell Street Arcade, Wolfe Tone Road, Dungarvan, Co. Waterford.", County="Co. Waterford",Type = Property_Type.DEASP, Cost_Centre="V4540",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8529",Address="Cork Homeless Persons, Unit 2B, Drinan Street, Cork, Co. Cork", County="Co. Cork",Type = Property_Type.DEASP, Cost_Centre="V4533",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8530",Address="Cork Homeless Persons, 3 Drinan Street, Cork, Co. Cork", County="Co. Cork",Type = Property_Type.DEASP, Cost_Centre="V4534",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8531",Address="Mallow CWS, 12 Lower Fair Street West, Mallow, Co. Cork ", County="Co. Cork ",Type = Property_Type.DEASP, Cost_Centre="V4535",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8535",Address="Kells CWS, Market Square, Kells, Co. Meath", County="Co. Meath",Type = Property_Type.DEASP, Cost_Centre="V4525",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8541",Address="Drogheda Intreo Centre, Employment Services, 1-2 Dyer Street, Drogheda, Co. Louth", County="Co. Louth",Type = Property_Type.DEASP, Cost_Centre="V4701",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8542",Address="Cavan Intreo Centre, Teach Cinn Ard, Thomas Ashe Street, Cavan, Co. Cavan", County="Co. Cavan",Type = Property_Type.DEASP, Cost_Centre="V4700",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8545",Address="Bantry Employment Services Office, Unit 2, The Warner Centre, Barrack Street, Bantry, Co. Cork", County="Co. Cork",Type = Property_Type.DEASP, Cost_Centre="V4746",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8552",Address="Dun Laoghaire Intreo Centre, 14 Cumberland Street, Dun Laoghaire, Co. Dublin", County="Co. Dublin",Type = Property_Type.DEASP, Cost_Centre="V4737",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8556",Address="Limerick CWS, 3rd Floor, Citygate House, Raheen Business Park, Limerick", County="Co. Limerick",Type = Property_Type.DEASP, Cost_Centre="V4731",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8557",Address="Limerick Public Services Card Centre, Pery Court, Upper Mallow Street, Limerick, Co. Limerick", County="Co. Limerick",Type = Property_Type.DEASP, Cost_Centre="V4728",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8558",Address="Nenagh Employment Services Office, 79 Connolly Street, Nenagh, Co. Tipperary", County="Co. Tipperary",Type = Property_Type.DEASP, Cost_Centre="V4729",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8561",Address="Ballybofey Employment Services Office, Units 4 & 5, Dunfril House, Chestnut Road, Ballybofey, Co. Donegal", County="Co. Donegal",Type = Property_Type.DEASP, Cost_Centre="V4705",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8568",Address="Edenderry Intreo Centre, National Contact Centre, Carrick Road, Edenderry, Co. Offaly", County="Co. Offaly",Type = Property_Type.DEASP, Cost_Centre="V4754",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8569",Address="Tuam Employment Services Office, High Street, Tuam, Co. Galway", County="Co. Galway",Type = Property_Type.DEASP, Cost_Centre="V4753",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8573",Address="Enniscorthy Employment Services Office, Unit 5, Bridgepoint, Abbey Square, Enniscorthy, Co. Wexford", County="Co. Wexford",Type = Property_Type.DEASP, Cost_Centre="V4722",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8574",Address="Wexford Intreo Centre(2), Unit A, St. Peter's Square, Wexford, Co. Wexford", County="Co. Wexford",Type = Property_Type.DEASP, Cost_Centre="V4721",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8580",Address="Maynooth Employment Services Office, Claremont House, Unit 2, Kelly's Lane, Maynooth, Co. Kildare", County="Co. Kildare",Type = Property_Type.DEASP, Cost_Centre="V4712",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8600",Address="Loughrea Intreo Centre, Railway House, Station Road, Loughrea, Co. Galway", County="Co. Galway",Type = Property_Type.DEASP, Cost_Centre="V3590",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8615",Address="Castleisland CWS, Tonnahy House, Killarney Road, Castleisland, Co. Kerry", County="Co. Kerry",Type = Property_Type.DEASP, Cost_Centre="V4789",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8617",Address="Carrigaline Intreo Centre, Ballea Road, Carrigaline, Co. Cork, Carrigaline, Co. Cork", County="Co. Cork",Type = Property_Type.DEASP, Cost_Centre="V4690",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8621",Address="Tralee Intreo Centre(2), 14 Edward Street, Tralee, Co. Kerry", County="Co. Kerry",Type = Property_Type.DEASP, Cost_Centre="V4797",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8625",Address="Cork Street Intreo Centre, The Guild Building, Brabazon Court, Cork Street, Dublin 8", County="Dublin 8 ",Type = Property_Type.DEASP, Cost_Centre="V4440",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8636",Address="Ballybofey CWS, Navenny House, Navenny Street, Ballybofey, Co. Donegal", County="Co. Donegal",Type = Property_Type.DEASP, Cost_Centre="V4137",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8638",Address="Cork Intreo Centre, Abbeycourt House, George's Quay, Cork, Co. Cork", County="Co. Cork",Type = Property_Type.DEASP, Cost_Centre="V4798",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8641",Address="Newbridge Intreo Centre, Moorefield Road, Newbridge, Co. Kildare", County="Co. Kildare",Type = Property_Type.DEASP, Cost_Centre="V4442",Team=Property_Team.Team_South},
new Property{OPW_Building_Code="B8650",Address="Balbriggan Intreo Centre, Gallen's Mill, Mill Street, Balbriggan, Co. Dublin", County="Co. Dublin",Type = Property_Type.DEASP, Cost_Centre="V3346",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8652",Address="Tuam Town Hall, The Square, Tuam, Co. Galway", County="Co. Galway",Type = Property_Type.DEASP, Cost_Centre="V4044",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8654",Address="Swords Intreo Centre, County Hall, Fingal County Council, Seatown Road, County Hall, Swords, Co. Dublin’", County="Co. Dublin",Type = Property_Type.DEASP, Cost_Centre="V4153",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8655",Address="Swords Intreo Centre, Mainscourt, 23 Main Street, Swords, Co. Dublin", County="Co. Dublin",Type = Property_Type.DEASP, Cost_Centre="V3344",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8656",Address="Galway Intreo Centre/ Regional Office, Sean Duggan Building, Fair Green Road, Galway, Co. Galway", County="Co. Galway",Type = Property_Type.DEASP, Cost_Centre="V4171",Team=Property_Team.Team_North},
new Property{OPW_Building_Code="B8673",Address="Dingle CWS, Unit 1, Górt a Lin, John Street , Dingle, Co. Kerry ", County="Co. Kerry",Type = Property_Type.DEASP, Cost_Centre="V4801",Team=Property_Team.Team_South},

                /*

                            new Property{OPW_Building_Code = "B0034", Address ="AMD,Store Street",County = "Dublin 1", Type = Property_Type.DEASP, Cost_Centre = "V4000", Team = Property_Team.Team_North},
                            new Property{OPW_Building_Code = "B1000", Address ="AMD,Store Street",County = "Dublin 1", Type = Property_Type.DEASP, Cost_Centre = "V4001", Team = Property_Team.Team_North},
                            new Property{OPW_Building_Code = "B0034", Address ="AMD,Store Street",County = "Dublin 1", Type = Property_Type.Branch_Office, Cost_Centre = "V3370", Team = Property_Team.Team_South},
                            new Property{OPW_Building_Code = "B0034", Address ="AMD,Store Street",County = "Dublin 1", Type = Property_Type.DEASP, Cost_Centre = "V4567", Team = Property_Team.Team_South},
                            new Property{OPW_Building_Code = "B0034", Address ="AMD,Store Street",County = "Dublin 1", Type = Property_Type.HSE_Location, Cost_Centre = "V7689", Team = Property_Team.Team_North},
                            new Property{OPW_Building_Code = "B1234", Address ="AMD,Store Street",County = "Dublin 1", Type = Property_Type.DEASP, Cost_Centre = "V6750", Team = Property_Team.Team_South},
                            new Property{OPW_Building_Code = "B0034", Address ="AMD,Store Street",County = "Dublin 1", Type = Property_Type.Branch_Office, Cost_Centre = "V4070", Team = Property_Team.Team_North},
                            */
            };
            property.ForEach(x => context.Opwproperty2.Add(x));
            context.SaveChanges();

            // Works test data
            var works = new List<Work>
            {
            //new Work{Property_ID = 1,User_ID = 1, Proj_Code = "001",Project_Desc= "fix sink" , Proj_budget_Requested = 2000, Status = Status.Pending_Approval},
            //new Work{Property_ID = 2,User_ID = 2, Proj_Code = "001",Project_Desc= "fix Alarm" , Proj_budget_Requested = 2600, Status = Status.Pending_Approval},
            //new Work{Project_ID = "PROJ 3", Property_ID = 3,User_ID = 3, Proj_Code = "002",Project_Desc= "fix ticket system" ,Proj_budget_Requested = 5000, Status = Status.Pending_Approval},
           // new Work{Project_ID = "PROJ 4", Property_ID = 4,User_ID = 3, Proj_Code = "002",Project_Desc= "DIY" ,Proj_budget_Requested = 5000, Status = Status.Approved},
           // new Work{Project_ID = "PROJ 5", Property_ID = 5,User_ID = 2, Proj_Code = "001",Project_Desc= "DIY 2" , Proj_budget_Requested = 2600, Status = Status.Funded},
            };
            works.ForEach(w => context.Opwwork2.Add(w));
            context.SaveChanges();
        }
             
    }
}