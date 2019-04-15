import { StudentEnrollments } from './studentenrollments';

export interface Student {
  id: number;
  cfssn: string;
  firstName: string;
  lastName: string;
  fatherName: string;
  gender: string;
  dateOfBirth: string;
  bloodGroup: string;
  religion: string;
  caste: string;
  motherTongue: string;
  nationality: string;
  firstAdmissionYear: number;
  emailId: string;
  currentAddress: string;
  currentCity: string;
  currentCityId: number;
  currentDistrict: string;
  currentDistrictId: number;
  pinCode: string;
  phoneWithStdCode: string;
  profilePicBinary: string;
  mobileNumber1: string;
  mobileNumber2: string;
  placeOfBirth: string;
  stateOfBirth: string;
  countryOfBirth: string;
  disabilityType: string;

  studentEnrollments?: StudentEnrollments[];
}
