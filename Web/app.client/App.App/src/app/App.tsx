import * as React from "react";
import { Route, Switch } from "react-router";
import { App as TextSearchApp } from "views/App";
import { LoginView } from "views/Login";
import { HistoryView } from "views/History/HistoryView";
import { hot } from "react-hot-loader";

export const App = hot(module)(() => (
  <>
    <Switch>
      <Route path="/history" component={HistoryView} />
      <Route path="/login" component={LoginView} />
      <Route path="" component={TextSearchApp} />
    </Switch>
  </>
));
