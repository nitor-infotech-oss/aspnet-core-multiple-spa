import React from 'react';
import { BrowserRouter as Router, Route, Link } from 'react-router-dom';

const AppName = 'Sample App 2';

const Index = () => <h2>{`${AppName} - Home`}</h2>;

const About = () => <h2>{`${AppName} - About`}</h2>;

const Users = () => <h2>{`${AppName} - Users`}</h2>;

export const AppRouter = () => {
  return (
    <Router basename={window.baseUrl || ''}>
      <div>
        <h1>{AppName}</h1>
        <nav>
          <ul>
            <li>
              <Link to="/">Home</Link>
            </li>
            <li>
              <Link to="/about/">About</Link>
            </li>
            <li>
              <Link to="/users/">Users</Link>
            </li>
          </ul>
        </nav>

        <Route path="/" exact component={Index} />
        <Route path="/about/" component={About} />
        <Route path="/users/" component={Users} />
      </div>
    </Router>
  );
};

export default AppRouter;
