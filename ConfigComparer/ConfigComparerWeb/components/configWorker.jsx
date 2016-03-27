var React = require('react');

module.exports = React.createClass({
  getInitialState: function() {
    return {fileContent: undefined};
  },
  
  onConfigFileSelect: function (e) {
    e.preventDefault();
    var fileReader = new FileReader();
    fileReader.onload = function(event) {
      this.setState({fileContent: event.target.result});
    }.bind(this);
    fileReader.readAsText(e.target.files[0]);
  },
  
  render: function() {
    var fileInfo;
    if (this.state.fileContent) {
      fileInfo = (
        <div>
          <p>File content:</p>
          <pre>{this.state.fileContent}</pre>
        </div>
      );
    } else {
      fileInfo = <p>File not selected</p>
    }
    
    return (
      <div>
        <p>Select .config file</p>
        <input type="file" accept=".config" onChange={this.onConfigFileSelect} />
        {fileInfo}
      </div>
    );
  }
});