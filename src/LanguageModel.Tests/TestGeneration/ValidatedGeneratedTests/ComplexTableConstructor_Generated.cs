﻿// Copyright (c) Microsoft. All rights reserved.

namespace LanguageModel.Tests.GeneratedTestFiles
{
    using LanguageModel.Tests.TestGeneration;
    using LanguageService;
    using Xunit;

    internal class ComplexTableConstructor_Generated
    {
        [Fact]
        public void Test(Tester t)
        {
            t.N(SyntaxKind.ChunkNode);
            {
                t.N(SyntaxKind.BlockNode);
                {
                    t.N(SyntaxKind.AssignmentStatementNode);
                    {
                        t.N(SyntaxKind.VarList);
                        {
                            t.N(SyntaxKind.NameVar);
                            {
                                t.N(SyntaxKind.Identifier);
                            }
                        }
                        t.N(SyntaxKind.AssignmentOperator);
                        t.N(SyntaxKind.ExpList);
                        {
                            t.N(SyntaxKind.TableConstructorExp);
                            {
                                t.N(SyntaxKind.OpenCurlyBrace);
                                t.N(SyntaxKind.FieldList);
                                {
                                    t.N(SyntaxKind.AssignmentField);
                                    {
                                        t.N(SyntaxKind.Identifier);
                                        t.N(SyntaxKind.AssignmentOperator);
                                        t.N(SyntaxKind.SimpleExpression);
                                        {
                                            t.N(SyntaxKind.Number);
                                        }
                                    }
                                    t.N(SyntaxKind.Comma);
                                    t.N(SyntaxKind.BracketField);
                                    {
                                        t.N(SyntaxKind.OpenBracket);
                                        t.N(SyntaxKind.SimpleExpression);
                                        {
                                            t.N(SyntaxKind.String);
                                        }
                                        t.N(SyntaxKind.CloseBracket);
                                        t.N(SyntaxKind.AssignmentOperator);
                                        t.N(SyntaxKind.SimpleExpression);
                                        {
                                            t.N(SyntaxKind.Number);
                                        }
                                    }
                                    t.N(SyntaxKind.Comma);
                                    t.N(SyntaxKind.AssignmentField);
                                    {
                                        t.N(SyntaxKind.Identifier);
                                        t.N(SyntaxKind.AssignmentOperator);
                                        t.N(SyntaxKind.SimpleExpression);
                                        {
                                            t.N(SyntaxKind.Number);
                                        }
                                    }
                                    t.N(SyntaxKind.Semicolon);
                                    t.N(SyntaxKind.ExpField);
                                    {
                                        t.N(SyntaxKind.SimpleExpression);
                                        {
                                            t.N(SyntaxKind.String);
                                        }
                                    }
                                    t.N(SyntaxKind.Comma);
                                    t.N(SyntaxKind.ExpField);
                                    {
                                        t.N(SyntaxKind.FunctionCallExp);
                                        {
                                            t.N(SyntaxKind.NameVar);
                                            {
                                                t.N(SyntaxKind.Identifier);
                                            }
                                            t.N(SyntaxKind.ParenArg);
                                            {
                                                t.N(SyntaxKind.OpenParen);
                                                t.N(SyntaxKind.ExpList);
                                                {
                                                    t.N(SyntaxKind.SimpleExpression);
                                                    {
                                                        t.N(SyntaxKind.String);
                                                    }
                                                }
                                                t.N(SyntaxKind.CloseParen);
                                            }
                                        }
                                    }
                                    t.N(SyntaxKind.Comma);
                                    t.N(SyntaxKind.BracketField);
                                    {
                                        t.N(SyntaxKind.OpenBracket);
                                        t.N(SyntaxKind.SimpleExpression);
                                        {
                                            t.N(SyntaxKind.Number);
                                        }
                                        t.N(SyntaxKind.CloseBracket);
                                        t.N(SyntaxKind.AssignmentOperator);
                                        t.N(SyntaxKind.TableConstructorExp);
                                        {
                                            t.N(SyntaxKind.OpenCurlyBrace);
                                            t.N(SyntaxKind.FieldList);
                                            {
                                                t.N(SyntaxKind.AssignmentField);
                                                {
                                                    t.N(SyntaxKind.Identifier);
                                                    t.N(SyntaxKind.AssignmentOperator);
                                                    t.N(SyntaxKind.SimpleExpression);
                                                    {
                                                        t.N(SyntaxKind.Number);
                                                    }
                                                }
                                            }
                                            t.N(SyntaxKind.CloseCurlyBrace);
                                        }
                                    }
                                    t.N(SyntaxKind.Comma);
                                    t.N(SyntaxKind.ExpField);
                                    {
                                        t.N(SyntaxKind.SimpleExpression);
                                        {
                                            t.N(SyntaxKind.String);
                                        }
                                    }
                                    t.N(SyntaxKind.Comma);
                                    t.N(SyntaxKind.ExpField);
                                    {
                                        t.N(SyntaxKind.SimpleExpression);
                                        {
                                            t.N(SyntaxKind.String);
                                        }
                                    }
                                }
                                t.N(SyntaxKind.CloseCurlyBrace);
                            }
                        }
                    }
                }
                t.N(SyntaxKind.EndOfFile);
            }
        }
    }
}