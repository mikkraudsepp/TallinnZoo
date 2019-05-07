const path = require('path');
const webpack = require('webpack');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const BundleAnalyzerPlugin = require('webpack-bundle-analyzer').BundleAnalyzerPlugin;
const bundleOutputDir = './wwwroot/dist';

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);
    return [{
        stats: { modules: false },
        entry: { 'main': './ClientSide/js/index.js' },
        resolve: { extensions: ['.js', '.jsx', '.ts', '.tsx'] },
        output: {
            path: path.join(__dirname, bundleOutputDir),
            filename: '[name].js',
            publicPath: './wwwroot/dist'
        },
        module: {
            rules: [
                {
                    test: /\.(s*)css$/,
                    use:
                        [
                            {
                                loader: MiniCssExtractPlugin.loader,
                                options: {
                                    // you can specify a publicPath here
                                    // by default it use publicPath in webpackOptions.output
                                    //publicPath: '../'
                                }
                            }, {
                                loader: 'css-loader', // translates CSS into CommonJS modules
                                options: {
                                    url: false // disables handling url('image.png')
                                }
                            }, {
                                loader: 'postcss-loader', // Run post css actions
                                options: {
                                    plugins: function () { // post css plugins, can be exported to postcss.config.js
                                        return [
                                            require('autoprefixer')
                                        ];
                                    }
                                }
                            }, {
                                loader: 'sass-loader', // compiles Sass to CSS
                            }]
                }
            ]
        },
        plugins: [
            new MiniCssExtractPlugin({
                // Options similar to the same options in webpackOptions.output
                // both options are optional
                filename: "[name].css",
                chunkFilename: "[id].css"
            }),
            new BundleAnalyzerPlugin({
                    generateStatsFile: true
                }
            )
        ].concat(isDevBuild ? [
            // Plugins that apply in development builds only
            new webpack.SourceMapDevToolPlugin({
                filename: '[file].map', // Remove this line if you prefer inline source maps
                moduleFilenameTemplate: path.relative(bundleOutputDir, '[resourcePath]') // Point sourcemap entries to the original file locations on disk
            })
        ] : [
                // Plugins that apply in production builds only
                new webpack.optimize.UglifyJsPlugin()
            ])
    }];
};
