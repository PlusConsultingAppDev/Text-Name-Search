import { createAction } from "redux-actions";
import { SourceTypeModel } from "models";

export namespace SourceTypeActions {
  export enum Type {
    ADD_OVERWRITE_SOURCETYPE = "ADD_OVERWRITE_SOURCETYPE",
  }

  export const AddOverwriteSourceType = createAction<SourceTypeModel[]>(Type.ADD_OVERWRITE_SOURCETYPE);

}

export type SourceTypeActions = Omit<typeof SourceTypeActions, "Type">;
