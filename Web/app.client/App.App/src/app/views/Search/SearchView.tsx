import * as React from "react";
import { bindActionCreators, Dispatch } from "redux";
import { connect } from "react-redux";
import { ArticleActions, SourceTypeActions, ResultActions, SearchActions } from "app/actions";
// import * as ArticleService from "app/services/articleService";
import * as ResultService from "app/services/resultService";
// import * as SourceTypeService from "app/services/sourceTypeService";
import * as searchService from "app/services/searchService";
import { Shell } from "app/components/Shell/shell";
// import { ArticleModel, ResultModel, SourceTypeModel } from "models";
import { SearchModel } from "models/searchModel";
import { RootState } from "app/reducers";
import { omit } from "core/utils";
import * as _ from "lodash";

export namespace SearchView {
  export interface LocalState {
    firstName: string;
    lastName: string;
    middleName: string;
    hasSaved: boolean;
  }

  export interface FluxProps {
    ArticleState: RootState.ArticleState;
    ResultState: RootState.ResultState;
    SourceTypeState: RootState.SourceTypeState;
    AuthenticationState: RootState.AuthenticationState;
    SearchState: RootState.SearchState;
  }

  export interface DispatchProps {
    articleActions: ArticleActions;
    resultActions: ResultActions;
    sourceTypeActions: SourceTypeActions;
    searchActions: SearchActions;
  }
}

@connect(
  (state: RootState, ownProps): Pick<SearchView.FluxProps,
    "ArticleState" | "ResultState" | "SourceTypeState" | "AuthenticationState" | "SearchState"> => {
    return {
      AuthenticationState: state.authenticationData,
      ArticleState: state.articleData,
      SourceTypeState: state.sourceTypeData,
      ResultState: state.resultData,
      SearchState: state.searchData,
    };
  },
  (dispatch: Dispatch): Pick<SearchView.DispatchProps,
    "articleActions" | "resultActions" | "sourceTypeActions" | "searchActions"> => ({
      articleActions: bindActionCreators(omit(ArticleActions, "Type"), dispatch),
      resultActions: bindActionCreators(omit(ResultActions, "Type"), dispatch),
      sourceTypeActions: bindActionCreators(omit(SourceTypeActions, "Type"), dispatch),
      searchActions: bindActionCreators(omit(SearchActions, "Type"), dispatch),
    }),
)

export class SearchView extends React.Component<SearchView.FluxProps & SearchView.DispatchProps, SearchView.LocalState> {
  // tslint:disable-next-line:no-any
  constructor(props: SearchView.FluxProps & SearchView.DispatchProps, context?: any) {
    super(props, context);
    this.state = {
      firstName: "",
      lastName: "",
      middleName: "",
      hasSaved: false,
    };
  }

  public render(): JSX.Element {
    const inputContainer = {
      marginTop: "8px",
    } as React.CSSProperties;
    const textBoxStyle = {
      borderRadius: 12,
      height: "28px",
      padding: "20px",
      width: "200px",
      align: "right",
    } as React.CSSProperties;
    const searchIconContainerStyle = {
      textAlign: "right",
    } as React.CSSProperties;
    const searchIconStyle = {
      position: "absolute",
      left: "132px",
      top: "11px",
    } as React.CSSProperties;
    const buttonStyle = {
      borderRadius: 12,
      width: "200px",
      position: "relative",
    } as React.CSSProperties;
    const formStyle = {
      textAlign: "center",
    } as React.CSSProperties;
    const searchButtonContainerStyle = {
      marginTop: "14px",
    } as React.CSSProperties;
    const saveButtonContainerStyle = {
      textAlign: "right",
      marginRight: "12px",
    } as React.CSSProperties;
    const labelStyle = {
      fontWeight: "bold",
    } as React.CSSProperties;
    const resultContainerStyle = {
      marginTop: "48px",
      borderRadius: 12,
      width: "400",
      paddingLeft: "36px",
      paddingTop: "8px",
      paddingBottom: "8px",
      border: "black solid 1px",
    } as React.CSSProperties;
    const resultContainerSavedStyle = {
      backgroundColor: "#696969",
    } as React.CSSProperties;
    return (
      <>
        <Shell hideFooter={true}>
          <div className="pure-form" style={formStyle}>
            <h1>
              Search Articles by full name
            </h1>
            <div id="TextInputContainer">
              <div>
                <div style={inputContainer}>
                  <input
                    id="fname"
                    name="fname"
                    type="text"
                    style={textBoxStyle}
                    placeholder="First Name"
                    onChange={
                      (e: React.FormEvent<HTMLInputElement>) =>
                        this.setState({ firstName: e.currentTarget.value })
                    }
                    onBlur={
                      (e: React.FormEvent<HTMLInputElement>) =>
                        this.setState({ firstName: e.currentTarget.value })
                    } />
                </div>
                <div style={inputContainer}>
                  <input
                    id="mname"
                    name="mname"
                    type="text"
                    style={textBoxStyle}
                    placeholder="Middle Name"
                    onChange={
                      (e: React.FormEvent<HTMLInputElement>) =>
                        this.setState({ middleName: e.currentTarget.value })
                    }
                    onBlur={
                      (e: React.FormEvent<HTMLInputElement>) =>
                        this.setState({ middleName: e.currentTarget.value })
                    } />
                </div>
                <div style={inputContainer}>
                  <input
                    id="lname"
                    name="lname"
                    type="text"
                    style={textBoxStyle}
                    placeholder="Last Name"
                    onChange={
                      (e: React.FormEvent<HTMLInputElement>) =>
                        this.setState({ lastName: e.currentTarget.value })
                    }
                    onBlur={
                      (e: React.FormEvent<HTMLInputElement>) =>
                        this.setState({ lastName: e.currentTarget.value })
                    } />
                </div>
              </div>
            </div>
            <div id="ButtonInputContainer" style={searchButtonContainerStyle}>
              <button
                type="button"
                style={buttonStyle}
                className="pure-button pure-button-primary"
                onClick={this.searchName}>
                Search
                <div style={searchIconContainerStyle}>
                  <i
                    style={searchIconStyle}
                    className="fa fa-search"
                    aria-hidden="true"
                    title="Search" />
                </div>
              </button>
            </div>
          </div>

          {this.props.SearchState.identifier &&
            <div style={!this.state.hasSaved ? resultContainerStyle : { ...resultContainerStyle, ...resultContainerSavedStyle }}>
              <div>
                <span style={labelStyle}>First Name:</span> {this.props.SearchState.firstName}
              </div>
              <div>
                <span style={labelStyle}>Last Name:</span> {this.props.SearchState.lastName}
              </div>
              <div>
                <span style={labelStyle}>Middle Name:</span> {this.props.SearchState.middleName}
              </div>
              <div>
                <span style={labelStyle}>Total Occurrences:</span> {_(this.props.SearchState.results).reduce((s, o) => {
                  return s + o.occurrences;
                }, 0)}
              </div>
              <div>
                <ul>
                  {this.props.SearchState.results.map((result, index) => (
                    <li>{result.searchText} ({result.occurrences})</li>
                  ))}
                </ul>
              </div>
              <div style={saveButtonContainerStyle}>
                {!this.state.hasSaved && <button
                  type="button"
                  style={buttonStyle}
                  className={!this.state.hasSaved ? "pure-button pure-button-primary" : "pure-button pure-button-secondary"}
                  onClick={this.saveResults}>
                  Save
                  <div style={searchIconContainerStyle}>
                    <i
                      style={searchIconStyle}
                      className="fa fa-save"
                      aria-hidden="true"
                      title="Search" />
                  </div>
                </button>}
              </div>
            </div>
          }
        </Shell>
      </>
    );
  }
  private searchName = async () => {
    this.setState({ hasSaved: false });
    const searchModel: SearchModel = await searchService.search(this.state.firstName, this.state.lastName, this.state.middleName);
    this.props.searchActions.AddOverwriteSearch(searchModel);
  }
  private saveResults = async () => {
    ResultService.add(this.props.SearchState.results).then(() => {
      this.setState({ hasSaved: true });
    });
  }
}
