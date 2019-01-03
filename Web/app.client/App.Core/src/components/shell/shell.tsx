import * as React from "react";
import { Header } from "./header";
import { Footer } from "./footer";
import { Sidebar } from "./sidebar";
import { User } from "core/models/user";

export type ShellProps = {
  user: User;
  history: string;
  sidebarVisible: boolean;
  logoUrl: string;
};

export type ShellEvents = {
  navigate: (url: string) => Promise<void>;
  getResults: () => Promise<void>;
};

export class Shell extends React.Component<ShellProps & ShellEvents, undefined> {
  public async componentWillMount(): Promise<void> {
    if (this.props.getResults()) {
      await this.props.getResults();
    }
  }

  public render(): JSX.Element {
    return (
      <div>
        <Header user={this.props.user} />
        <div style={{ width: "80%", margin: "auto", marginTop: "30px", marginBottom: "75px", display: "table" }}>
          <div style={{ borderBottom: "1px solid #ccc" }}>
            {<Sidebar />}
            <div style={{ padding: "0 20px" }}>
              {this.props.children}
            </div>
            <Footer imgLogo={this.props.logoUrl} />
          </div>
        </div>
      </div>
    );
  }
}
