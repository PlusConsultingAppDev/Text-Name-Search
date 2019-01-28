var webpackMerge = require('webpack-merge');
var HtmlWebpackPlugin = require('html-webpack-plugin');
var ExtractTextPlugin = require('extract-text-webpack-plugin');
var commonConfig = require('./webpack.common.js');
var helpers = require('./helpers');

module.exports = webpackMerge(commonConfig, {
	devtool: 'source-map',
	module: {
		rules: [
			{
				test: /\.ts$/,
				loaders: ['awesome-typescript-loader', 'angular2-template-loader', 'angular-router-loader']
			}, {
				test: /\.css$/,
				exclude: helpers.root('src', 'app'),
				loader: ExtractTextPlugin.extract({ fallback: 'style-loader', use: 'css-loader' })
			}
		],
	},
	output: {
		path: helpers.root('dist'),
		publicPath: 'http://localhost:8080/',
		filename: '[name].js',
		chunkFilename: '[id].chunk.js'
	},

	plugins: [
		new ExtractTextPlugin('[name].css'),
		new HtmlWebpackPlugin({
			template: 'src/index-dev.html'
		})
	],

	devServer: {
		historyApiFallback: true,
		stats: 'minimal'
	}
});