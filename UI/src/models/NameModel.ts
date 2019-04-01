export class NameModel {
  public count: number;

  constructor(public id: string, public firstName: string, public middleName: string, public lastName: string) {
    this.count = 0;
  }
}

export interface NameModel {
  id: string;
  firstName: string;
  middleName: string;
  lastName: string;
  count: number;
}
