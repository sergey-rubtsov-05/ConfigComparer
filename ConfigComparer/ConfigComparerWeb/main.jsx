var React = require('react');
var ReactDOM = require('react-dom');

var Hello = require('./components/hello');
var ConfigWorker = require('./components/configWorker');
var AppBar = require('material-ui/lib/app-bar').default;
var Paper = require('material-ui/lib/paper').default;

ReactDOM.render(
  <div>
    <AppBar title="Header" showMenuIconButton={false} />
    <Paper>
      <Hello />
      <ConfigWorker />
    </Paper>
    <AppBar title="Footer" showMenuIconButton={false} />
  </div>, document.getElementById('container'));