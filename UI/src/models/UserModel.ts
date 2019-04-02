export class UserModel {
  constructor(public emailAddress: string, public password: string) {}
}

export interface UserModel {
  emailAddress: string;
  password: string;
}
