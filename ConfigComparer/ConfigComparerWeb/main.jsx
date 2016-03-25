var React = require('react');
var ReactDOM = require('react-dom');

var Hello = React.createClass({
    getInitialState: function () {
        return {text: undefined}
    },
    
    getDefaultProps: function () {
        return {text: "World"}
    },
    
    onTextChange: function (e) {
        e.preventDefault();
        this.setState({text: e.target.value});
    },
    
    render: function() {
        var text;
        if (this.state.text) {
            text = this.state.text;
        } else {
            text = this.props.text;
        }
        return (
            <div>
                <input type="text" value={this.state.text} onChange={this.onTextChange} />
                <h1>Hello, {text}!</h1>
            </div>);
    }
});

ReactDOM.render(<Hello />, document.getElementById('container'));