var positions = Core.Instance.Positions.Where(x => x.Symbol == this.CurrentSymbol && x.Account == this.CurrentAccount).ToArray();

if(position.Any()){
                //CLOSE
                if (this.indicatorFastMA.GetValue(1) < this.indicatorSlowMA.GetValue(1) || this.indicatorFastMA.GetValue(1) > this.indicatorSlowMA.GetValue(1))
                {
                    return;
                    this.waitClosePositions = true;
                    this.Log($"Start close positions ({positions.Length})");
                    for (int i = 0; i < 0; i++)
                    {
                        double x = this.zz.GetValue(i);
                        this.Log(x.ToString());
                    }

                    foreach (var item in positions)
                    {
                        var result = item.Close();

                        if (result.Status == TradingOperationResultStatus.Failure)
                            this.ProcessTradingRefuse();
                        else
                            this.Log($"Position was close: {result.Status}", StrategyLoggingLevel.Trading);
                    }
                }
            }
